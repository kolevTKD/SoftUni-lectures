namespace VillainNames
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");

            await connection.OpenAsync();

            string result = await GetAllMinionsPerVillainAsync(connection);
            Console.WriteLine(result);
        }

        static async Task<string> GetAllMinionsPerVillainAsync(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand villainsAndMinionsCmd = new SqlCommand
               (@"    SELECT [Name]
                           , COUNT(mv.MinionId) AS [MinionsCount]
                        FROM Villains AS v
                  INNER JOIN MinionsVillains AS mv
                          ON v.Id = mv.VillainId
                       GROUP BY v.[Name]
                      HAVING COUNT(mv.MinionId) > 3
                    ORDER BY COUNT(mv.MinionId) DESC", connection);

            SqlDataReader reader = await villainsAndMinionsCmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}