using EntityRelationsTest.Data;

namespace EntityRelationsTest
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DemoDbContext context = new DemoDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Db Created successfully!");
        }
    }
}
