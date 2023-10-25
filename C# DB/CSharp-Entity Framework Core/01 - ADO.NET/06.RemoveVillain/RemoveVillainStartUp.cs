namespace RemoveVillain
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                await CheckIfVillainExistsAsync(connection, transaction, sb, villainId);
                await ReleaseMinionsAsync(connection, transaction, sb, villainId);
                await DeleteVillainAsync(connection, transaction, villainId);

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static async Task CheckIfVillainExistsAsync(SqlConnection connection, SqlTransaction transaction, StringBuilder sb, int villainId)
        {
            SqlCommand checkIfVillainExistsCmd = new SqlCommand
                (@"SELECT Name FROM Villains WHERE Id = @villainId", connection, transaction);
            checkIfVillainExistsCmd.Parameters.AddWithValue("@villainId", villainId);
            SqlDataReader reader = await checkIfVillainExistsCmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                Console.WriteLine($"No such villain was found.");
                Environment.Exit(0);
            }

            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} was deleted.");
            }

            reader.Close();
        }

        private static async Task ReleaseMinionsAsync(SqlConnection connection, SqlTransaction transaction, StringBuilder sb, int villainId)
        {
            SqlCommand releaseMinionsCmd = new SqlCommand
               (@"DELETE FROM MinionsVillains 
                         WHERE VillainId = @villainId", connection, transaction);
            releaseMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

            int minionsReleasedCount = await releaseMinionsCmd.ExecuteNonQueryAsync();
            await releaseMinionsCmd.ExecuteNonQueryAsync();
            sb.AppendLine($"{minionsReleasedCount} minions were released.");
        }

        private static async Task DeleteVillainAsync(SqlConnection connection, SqlTransaction transaction, int villainId)
        {
            SqlCommand deleteVillainCmd = new SqlCommand
                (@"DELETE FROM Villains
                         WHERE Id = @villainId", connection, transaction);
            deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await deleteVillainCmd.ExecuteNonQueryAsync();
        }
    }
}