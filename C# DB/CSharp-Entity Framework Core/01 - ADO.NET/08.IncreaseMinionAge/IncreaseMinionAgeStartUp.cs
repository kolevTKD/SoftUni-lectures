namespace IncreaseMinionAge
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (int minionId in minionIds)
                {
                    SqlCommand updateMinionAgeAndNameCmd = new SqlCommand
                    (@"UPDATE Minions
                      SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                    WHERE Id = @Id", connection, transaction);

                    updateMinionAgeAndNameCmd.Parameters.AddWithValue("@Id", minionId);
                    await updateMinionAgeAndNameCmd.ExecuteNonQueryAsync();
                }

                SqlCommand getAllMinionsCmd = new SqlCommand
                    (@"SELECT Name, Age FROM Minions", connection, transaction);

                StringBuilder sb = new StringBuilder();

                using (SqlDataReader reader = await getAllMinionsCmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }

                transaction.Commit();
                Console.WriteLine(sb.ToString().TrimEnd());
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
    }
}