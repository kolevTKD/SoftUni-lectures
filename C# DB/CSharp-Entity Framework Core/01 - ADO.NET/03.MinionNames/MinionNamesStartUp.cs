namespace MinionNames
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();

            int villainId = int.Parse(Console.ReadLine());

            string result = await GetMinionInfoPerVillainAsync(connection, villainId);

            Console.WriteLine(result);
        }

        static async Task<string> GetMinionInfoPerVillainAsync(SqlConnection connection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand villainNameCmd = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @Id", connection);
            villainNameCmd.Parameters.AddWithValue("@Id", villainId);

            string? villainName = (string?)await villainNameCmd.ExecuteScalarAsync();

            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }


            SqlCommand minionsInfoCmd = new SqlCommand
                (@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name", connection);

            minionsInfoCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader reader = await minionsInfoCmd.ExecuteReaderAsync();

            return await GetMinionsOfVillainsAsync(reader, villainName);
        }

        private static async Task<string> GetMinionsOfVillainsAsync(SqlDataReader reader, string villainName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Villain: {villainName}");

            if (!reader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }

            while (await reader.ReadAsync())
            {
                long rowNum = (long)reader["RowNum"];
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];

                sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}