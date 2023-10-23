namespace AddMinion
{
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();
        }
    }
}