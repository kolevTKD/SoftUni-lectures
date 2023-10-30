namespace MiniORM;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

internal class ChangeTracker<T>
    where T : class, new()
{
    private readonly IList<T> allEntities;
    private readonly IList<T> added;
    private readonly IList<T> removed;

    public ChangeTracker(IEnumerable<T> entities)
    {
        added = new List<T>();
        removed = new List<T>();
        allEntities = CloneEntities(entities);
    }

    public IReadOnlyCollection<T> AllEntities => (IReadOnlyCollection<T>)allEntities;
    public IReadOnlyCollection<T> Added => (IReadOnlyCollection<T>)added;
    public IReadOnlyCollection<T> Removed => (IReadOnlyCollection<T>)removed;

    

    private IList<T> CloneEntities(IEnumerable<T> entities) //ICollection?
    {
        IList<T> clonedEntities = new List<T>();
        PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
            .ToArray();

        foreach (T entity in entities)
        {
            T clonedEntity = Activator.CreateInstance<T>();
            foreach (PropertyInfo property in propertiesToClone)
            {
                object value = property.GetValue(entity);
                property.SetValue(clonedEntity, value);
            }
            clonedEntities.Add(clonedEntity);
        }
        return clonedEntities;
    }

    public void Add(T item) => added.Add(item);
    public void Remove(T item) => removed.Add(item);//--------

    public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
    {
        IList<T> modifiedEntities = new List<T>();
        PropertyInfo[] primaryKeys = typeof(T).GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        foreach (T proxyEntity in AllEntities)
        {
            object[] primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity)
                .ToArray();
            T entity = dbSet.Entities.FirstOrDefault(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

            if (entity == null)
            {
                continue;
            }

            bool isModified = IsModified(proxyEntity, entity);
            if (isModified)
            {
                modifiedEntities.Add(proxyEntity);
            }
        }
        return modifiedEntities;
    }
    private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T proxyEntity)
        => primaryKeys.Select(pk => pk.GetValue(proxyEntity));

    private bool IsModified(T proxyEntity, T entity)
    {
        PropertyInfo[] monitoredProperties = typeof(T).GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
            .ToArray();

        PropertyInfo[] modifiedProperties = monitoredProperties
            .Where(pi => !Equals(pi.GetValue(proxyEntity), pi.GetValue(entity)))
            .ToArray();
        bool isModified = modifiedProperties.Any();

        return isModified;
    }
}
