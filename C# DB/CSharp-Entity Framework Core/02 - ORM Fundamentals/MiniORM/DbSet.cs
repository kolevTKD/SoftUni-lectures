namespace MiniORM;

using System.Collections;

public class DbSet<TEntity> : ICollection<TEntity>
    where TEntity : class, new()
{
    internal DbSet(IEnumerable<TEntity> entities)
    {
        Entities = entities.ToList();
        ChangeTracker = new ChangeTracker<TEntity>(entities);
    }
    internal ChangeTracker<TEntity> ChangeTracker { get; set; }
    internal ICollection<TEntity> Entities { get; set; }
    public int Count => Entities.Count;
    public bool IsReadOnly => Entities.IsReadOnly;

    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Item cannot be null");
        }
        Entities.Add(entity);
        ChangeTracker.Add(entity);

    }

    public void Clear()
    {
        while (Entities.Any())
        {
            TEntity entity = Entities.First();
            Remove(entity);
        }
    }

    public bool Contains(TEntity item) => Entities.Contains(item);

    public void CopyTo(TEntity[] arr, int arrIndex) => Entities.CopyTo(arr, arrIndex);

    public bool Remove(TEntity item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("Item cannot be null");
        }

        bool removedSuccessfully = Entities.Remove(item);

        if (removedSuccessfully)
        {
            ChangeTracker.Remove(item);
        }
        return removedSuccessfully;
    }

    public IEnumerator<TEntity> GetEnumerator() => Entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
        {
            Remove(entity);
        }
    }
}

