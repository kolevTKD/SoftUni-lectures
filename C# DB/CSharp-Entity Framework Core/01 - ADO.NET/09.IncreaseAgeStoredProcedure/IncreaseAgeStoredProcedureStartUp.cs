namespace IncreaseAgeStoredProcedure
{
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand executeSPCmd = new SqlCommand
                    (@"EXEC usp_GetOlder @id", connection, transaction);
                executeSPCmd.Parameters.AddWithValue("@id", id);

                await executeSPCmd.ExecuteNonQueryAsync();

                SqlCommand getAffectedMinionInfoCmd = new SqlCommand
                    (@"SELECT Name, Age FROM Minions WHERE Id = @Id", connection, transaction);
                getAffectedMinionInfoCmd.Parameters.AddWithValue(@"Id", id);

                using (SqlDataReader reader = await getAffectedMinionInfoCmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"].ToString().Trim()} - {reader["Age"]} years old");
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
    }
}