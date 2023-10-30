namespace MiniORM;

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

using Microsoft.Data.SqlClient;

public abstract class DbContext
{
    private readonly DatabaseConnection connection;
    private readonly IDictionary<Type, PropertyInfo> dbSetProperties;

    public DbContext(string connectionString)
    {
        connection = new DatabaseConnection(connectionString);
        dbSetProperties = DiscoverDbSets();
        using (new ConnectionManager(connection))
        {
            InitializeDbSets();
        }
        MapAllRelations();
    }

    internal static readonly Type[] AllowedSqlTypes =
    {
        typeof(string),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
        typeof(decimal),
        typeof(bool),
        typeof(DateTime),
    };

    private IDictionary<Type, PropertyInfo> DiscoverDbSets()
    {
        IDictionary<Type, PropertyInfo> dbSets = GetType().GetProperties()
            .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);
        return dbSets;
    }

    private void MapAllRelations()
    {
        foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in dbSetProperties)
        {
            Type dbSetType = dbSetProperty.Key;
            MethodInfo mapRelationsGeneric = typeof(DbContext)
                .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(dbSetType);
            object dbSet = dbSetProperty.Value.GetValue(this);
            mapRelationsGeneric.Invoke(this, new object[] { dbSet });
        }
    }

    private void InitializeDbSets()
    {
        foreach (KeyValuePair<Type, PropertyInfo> dbSet in dbSetProperties)
        {
            Type dbSetType = dbSet.Key;
            PropertyInfo dbSetProperty = dbSet.Value;

            MethodInfo populateDbSetGeneric = typeof(DbContext)
                .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(dbSetType);
            populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
        }
    }

    public void SaveChanges()
    {
        object[] dbSets = dbSetProperties
            .Select(pi => pi.Value.GetValue(this))
            .ToArray();

        foreach (IEnumerable<object> dbSet in dbSets)
        {
            IEnumerable<object> invalidEntities = dbSet
                .Where(entity => !IsObjectValid(entity))
                .ToArray();

            if (invalidEntities.Any())
            {
                throw new InvalidOperationException($"{invalidEntities.Count()} Invalid Entities Found in {dbSet.GetType().Name}");
            }
        }

        using (new ConnectionManager(connection))
        {
            using SqlTransaction transaction = connection.StartTransaction();

                foreach (IEnumerable dbSet in dbSets)
                {
                    Type dbSetType = dbSet.GetType().GetGenericArguments().First();
                    MethodInfo persistMethod = typeof(DbContext)
                        .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                        .MakeGenericMethod(dbSetType);

                    try
                    {
                        persistMethod.Invoke(this, new object[] { dbSet });
                    }
                    catch (TargetInvocationException tie)
                    {
                        throw tie.InnerException;
                    }
                    catch (InvalidOperationException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            transaction.Commit();

        }
    }

    private bool IsObjectValid(object e)
    {
        ValidationContext validationContext = new ValidationContext(e);
        ICollection<ValidationResult> validationErrors = new List<ValidationResult>();

        bool validationResult = Validator.TryValidateObject(e, validationContext, validationErrors, true);
        return validationResult;
    }

    private void Persist<TEntity>(DbSet<TEntity> dbSet)
        where TEntity : class, new()
    {
        string tableName = GetTableName(typeof(TEntity));
        string[] columns = connection.FetchColumnNames(tableName).ToArray();
        if (dbSet.ChangeTracker.Added.Any())
        {
            connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
        }

        IEnumerable<TEntity> modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
        if (modifiedEntities.Any())
        {
            connection.UpdateEntities(modifiedEntities, tableName, columns);
        }
        if (dbSet.ChangeTracker.Removed.Any())
        {
            connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
        }
    }

    private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
        where TEntity : class, new()
    {
        IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();
        DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);
        ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
    }

    private IEnumerable<TEntity> LoadTableEntities<TEntity>()
        where TEntity : class, new()
    {
        Type table = typeof(TEntity);
        string[] columns = GetEntityColumnNames(table);
        string tableName = GetTableName(table);

        IEnumerable<TEntity> fetchedRows = connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
        return fetchedRows;
    }

    private string GetTableName(Type type)
    {
        string tableName = type.GetCustomAttribute<TableAttribute>()?.Name;
        if (tableName == null)
        {
            tableName = dbSetProperties[type].Name;
        }

        return tableName;
    }

    private string[] GetEntityColumnNames(Type table)
    {
        string tableName = GetTableName(table);
        string[] dbColumns = connection.FetchColumnNames(tableName).ToArray();

        string[] columns = table.GetProperties()
            .Where(pi => dbColumns.Contains(pi.Name) &&
                         !pi.HasAttribute<NotMappedAttribute>() &&
                         AllowedSqlTypes.Contains(pi.PropertyType))
            .Select(pi => pi.Name)
            .ToArray();

        return columns;
    }

    private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
        where TEntity : class, new()
    {
        Type entityType = typeof(TEntity);
        MapNavigationProperties(dbSet);
        PropertyInfo[] collections = entityType
            .GetProperties()
            .Where(pi =>
                pi.PropertyType.IsGenericType &&
                pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection))
            .ToArray();

        foreach (PropertyInfo collection in collections)
        {
            Type collectionType = collection.PropertyType.GetGenericArguments().First();
            MethodInfo mapCollectionMethod = typeof(DbContext)
                .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(entityType, collectionType);
            mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
        }
    }

    private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
        where TEntity : class, new()
    {
        Type entityType = typeof(TEntity);

        PropertyInfo[] foreignKeys = entityType.GetProperties()
            .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
            .ToArray();

        foreach (PropertyInfo foreignKey in foreignKeys)
        {
            string navigationPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;
            PropertyInfo navigationProperty = entityType.GetProperty(navigationPropertyName);

            IEnumerable<object> navigationDbSet = (IEnumerable<object>)dbSetProperties[navigationProperty.PropertyType]
                .GetValue(this);

            PropertyInfo navigationPrimaryKey = navigationProperty.PropertyType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            foreach (TEntity entity in dbSet)
            {
                object foreignKeyValue = foreignKey.GetValue(entity);

                object navigationPropertyValue = navigationDbSet
                    .First(currentNavigationProperty => navigationPrimaryKey.GetValue(currentNavigationProperty).Equals(foreignKeyValue));

                navigationProperty.SetValue(entity, navigationPropertyValue);
            }
        }
    }

    private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
        where TDbSet : class, new()
        where TCollection : class, new()
    {
        Type entityType = typeof(TDbSet);
        Type collectionType = typeof(TCollection);

        PropertyInfo[] primaryKeys = collectionType.GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();
        PropertyInfo primaryKey = primaryKeys.First();

        PropertyInfo foreignKey = entityType.GetProperties()
            .First(pi => pi.HasAttribute<KeyAttribute>());

        bool isManyToMany = primaryKeys.Length >= 2;
        if (isManyToMany)
        {
            primaryKey = collectionType.GetProperties()
                .First(pi => collectionType
                                .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                                .PropertyType == entityType);
        }

        DbSet<TCollection> navigationDbSet = (DbSet<TCollection>)dbSetProperties[collectionType].GetValue(this);

        foreach (TDbSet entity in dbSet)
        {
            object primaryKeyValue = foreignKey.GetValue(entity);
            IEnumerable<TCollection> navigationEntities = navigationDbSet
                .Where(navigationEntity => primaryKey.GetValue(navigationEntity).Equals(primaryKeyValue))
                .ToArray();

            ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
        }
    }
}

