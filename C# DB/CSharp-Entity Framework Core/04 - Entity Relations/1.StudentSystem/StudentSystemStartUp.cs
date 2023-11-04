namespace P01_StudentSystem
{
    using Data;
    public class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}