using System.Text;

using Microsoft.Data.SqlClient;

namespace ADO.NETExRecap
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();

            using (connection)
            {
                string result = await IncreaseAgeStoredProcedureAsync(connection);

                Console.WriteLine(result);
            }
        }
        static async Task<string> VillainNamesAsync(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(@"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                        FROM Villains AS v 
                                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                    GROUP BY v.Id, v.Name 
                                                      HAVING COUNT(mv.VillainId) > 3 
                                                    ORDER BY COUNT(mv.VillainId)", connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            using (reader)
            {
                StringBuilder sb = new StringBuilder();

                while (await reader.ReadAsync())
                {
                    sb.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                }

                return sb.ToString().TrimEnd();
            }
        } //02

        static async Task<string> MinionNamesAsync(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            int id = int.Parse(Console.ReadLine());

            SqlCommand findVillainCommand = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @Id", connection);
            findVillainCommand.Parameters.AddWithValue("@Id", id);

            string? villainName = (string?)await findVillainCommand.ExecuteScalarAsync();

            if (villainName == null)
            {
                return $"No villain with ID {id} exists in the database.";
            }

            sb.AppendLine($"Villain: {villainName}");

            SqlCommand minionsInfo = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                             m.Name, 
                                                             m.Age
                                                        FROM MinionsVillains AS mv
                                                        JOIN Minions As m ON mv.MinionId = m.Id
                                                       WHERE mv.VillainId = @Id
                                                    ORDER BY m.Name", connection);

            minionsInfo.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = await minionsInfo.ExecuteReaderAsync();

            using (reader)
            {
                if (!reader.HasRows)
                {
                    sb.AppendLine("(no minions)");
                    return sb.ToString().TrimEnd();
                }

                while (await reader.ReadAsync())
                {
                    long rowNum = (long)reader["RowNum"];
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];

                    sb.AppendLine($"{rowNum}. {name} {age}");
                }
            }

            return sb.ToString().TrimEnd();
        } //03

        static async Task<string> AddMinionAsync(SqlConnection connection)
        {
            string[] minionParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionParams[1];
            int minionAge = int.Parse(minionParams[2]);
            string minionTown = minionParams[3];

            string[] villainParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string villainName = villainParams[1];

            StringBuilder sb = new StringBuilder();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {

                SqlCommand findTownCmd = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", connection, transaction);
                findTownCmd.Parameters.AddWithValue("@townName", minionTown);

                int? townId = (int?)await findTownCmd.ExecuteScalarAsync();

                if (townId == null)
                {
                    SqlCommand addTownCmd = new SqlCommand(@"INSERT INTO Towns (Name) VALUES (@townName)", connection, transaction);
                    addTownCmd.Parameters.AddWithValue("@townName", minionTown);
                    await addTownCmd.ExecuteNonQueryAsync();

                    townId = (int?)await findTownCmd.ExecuteScalarAsync();

                    sb.AppendLine($"Town {minionTown} was added to the database.");
                }

                SqlCommand findVillainCmd = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @Name", connection, transaction);
                findVillainCmd.Parameters.AddWithValue("@Name", villainName);

                int? villainId = (int?)await findVillainCmd.ExecuteScalarAsync();

                if (villainId == null)
                {
                    SqlCommand addVillainCmd = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", connection, transaction);
                    addVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                    await addVillainCmd.ExecuteNonQueryAsync();

                    villainId = (int?)await findVillainCmd.ExecuteScalarAsync();

                    sb.AppendLine($"Villain {villainName} was added to the database.");
                }

                SqlCommand findMinionCmd = new SqlCommand(@"SELECT Id FROM Minions WHERE Name = @Name", connection, transaction);
                findMinionCmd.Parameters.AddWithValue("@Name", minionName);


                //if (minionId == null)
                //{
                //}
                SqlCommand addMinionCmd = new SqlCommand(@"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", connection, transaction);
                addMinionCmd.Parameters.AddWithValue("@name", minionName);
                addMinionCmd.Parameters.AddWithValue("@age", minionAge);
                addMinionCmd.Parameters.AddWithValue("@townId", townId);
                await addMinionCmd.ExecuteNonQueryAsync();

                int? minionId = (int?)await findMinionCmd.ExecuteScalarAsync();

                SqlCommand checkExistance = new SqlCommand(@"SELECT MinionId, VillainId FROM MinionsVillains WHERE MinionId = @minionId AND VillainId = @villainId", connection, transaction);
                checkExistance.Parameters.AddWithValue("@minionId", minionId);
                checkExistance.Parameters.AddWithValue("@villainId", villainId);

                SqlDataReader reader = await checkExistance.ExecuteReaderAsync();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        SqlCommand addMinionToVillainCmd = new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", connection, transaction);
                        addMinionToVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                        addMinionToVillainCmd.Parameters.AddWithValue("@villainId", villainId);

                        reader.Close();
                        await addMinionToVillainCmd.ExecuteNonQueryAsync();

                    }
                }

                await transaction.CommitAsync();
                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                Console.WriteLine(e.Message);
            }

            return sb.ToString().TrimEnd();
        } //04

        static async Task<string> ChangeTownNamesCasingAsync(SqlConnection connection)
        {
            string countryName = Console.ReadLine();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                StringBuilder sb = new StringBuilder();

                SqlCommand updatedTowns = new SqlCommand(@"UPDATE Towns
                                                              SET Name = UPPER(Name)
                                                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection, transaction);
                updatedTowns.Parameters.AddWithValue("@countryName", countryName);

                int recordsAffected = await updatedTowns.ExecuteNonQueryAsync();

                List<string> townNames = new List<string>();
                //int i = 0;

                sb.AppendLine($"{recordsAffected} town names were affected.");

                //--------------------------------------------------------------------------------------------------------------------------
                SqlCommand findTownsCmd = new SqlCommand(@"SELECT t.Name 
                                                         FROM Towns as t
                                                         JOIN Countries AS c ON c.Id = t.CountryCode
                                                        WHERE c.Name = @countryName", connection, transaction);
                findTownsCmd.Parameters.AddWithValue("@countryName", countryName);
                using SqlDataReader reader = await findTownsCmd.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No town names were affected.");
                    await reader.CloseAsync();
                    await transaction.RollbackAsync();
                    Environment.Exit(0);
                }

                while (await reader.ReadAsync())
                {
                    townNames.Add((string)reader["Name"]);
                }

                sb.AppendLine($"[{string.Join(", ", townNames)}]");
                await reader.CloseAsync();

                await transaction.CommitAsync();
                return sb.ToString().TrimEnd();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return e.Message;
            }

        } //05

        static async Task<string> RemoveVillainAsync(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand findVillainName = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @villainId", connection, transaction);
                findVillainName.Parameters.AddWithValue("@villainId", villainId);

                string? villainName = (string?)await findVillainName.ExecuteScalarAsync();

                if (villainName == null)
                {
                    await transaction.RollbackAsync();

                    Console.WriteLine("No such villain was found.");
                    Environment.Exit(0);
                }

                SqlCommand removeFromVillMin = new SqlCommand(@"DELETE FROM MinionsVillains 
                                                             WHERE VillainId = @villainId", connection, transaction);
                removeFromVillMin.Parameters.AddWithValue("@villainId", villainId);

                int minionsReleased = await removeFromVillMin.ExecuteNonQueryAsync();


                SqlCommand removeVillain = new SqlCommand(@"DELETE FROM Villains
                                                             WHERE Id = @villainId", connection, transaction);
                removeVillain.Parameters.AddWithValue("@villainId", villainId);

                await removeVillain.ExecuteNonQueryAsync();

                sb.AppendLine($"{villainName} was deleted.")
                  .AppendLine($"{minionsReleased} minions were released.");

                return sb.ToString().TrimEnd();
            }

            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return e.Message;
            }
        } //06

        static async Task<string> PrintAllMinionNamesAsync(SqlConnection connection)
        {
            SqlCommand getAllNamesAsync = new SqlCommand(@"SELECT Name FROM Minions", connection);
            SqlDataReader reader = await getAllNamesAsync.ExecuteReaderAsync();

            List<string> minionNames = new List<string>();
            while (await reader.ReadAsync())
            {
                minionNames.Add((string)reader["Name"]);
            }

            StringBuilder sb = new StringBuilder();
            int count = minionNames.Count;

            for (int i = 0; i < count / 2; i++)
            {
                sb.AppendLine(minionNames[i]);
                sb.AppendLine(minionNames[count - 1 - i]);
            }

            if (count % 2 != 0)
            {
                sb.AppendLine(minionNames[count / 2]);
            }

            return sb.ToString().TrimEnd();
        } //07

        static async Task<string> IncreaseMinionAgeAsync(SqlConnection connection)
        {
            int[] minionIDs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            StringBuilder sb = new StringBuilder();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (int minionId in minionIDs)
                {
                    SqlCommand updateMinionNameAndAge = new SqlCommand(@"UPDATE Minions
                                                                        SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                                      WHERE Id = @Id", connection, transaction);
                    updateMinionNameAndAge.Parameters.AddWithValue("@Id", minionId);

                    await updateMinionNameAndAge.ExecuteNonQueryAsync();
                }

                SqlCommand getAllMinionsInfo = new SqlCommand(@"SELECT Name, Age FROM Minions", connection, transaction);

                using SqlDataReader reader = await getAllMinionsInfo.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
                }

                await reader.CloseAsync();

                await transaction.CommitAsync();

            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return e.Message;
            }

            return sb.ToString().TrimEnd();
        } //08

        static async Task<string> IncreaseAgeStoredProcedureAsync(SqlConnection connection)
        {
            int minionId = int.Parse(Console.ReadLine());
            string result = string.Empty;

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {

                SqlCommand execStoredProc = new SqlCommand(@"EXEC dbo.usp_GetOlder @id", connection, transaction);
                execStoredProc.Parameters.AddWithValue("@id", minionId);

                await execStoredProc.ExecuteNonQueryAsync();

                SqlCommand getUpdatedMinion = new SqlCommand(@"SELECT Name, Age FROM Minions WHERE Id = @Id", connection, transaction);
                getUpdatedMinion.Parameters.AddWithValue("@Id", minionId);

                using SqlDataReader reader = await getUpdatedMinion.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result = $"{reader["Name"]} - {reader["Age"]} years old";
                }

                await reader.CloseAsync();
                await transaction.CommitAsync();

                return result;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return e.Message;
            }
        } //09
    }
}
