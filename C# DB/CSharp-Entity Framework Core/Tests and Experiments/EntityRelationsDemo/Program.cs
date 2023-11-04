using EntityRelationsDemo.Data;

namespace EntityRelationsDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}