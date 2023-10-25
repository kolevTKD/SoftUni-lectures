namespace AddMinion
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] villainInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;

            await using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                result = await AddMinionsAndVillainsToDatabaseAsync(connection, transaction, minionInfo, villainInfo);
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await transaction.RollbackAsync();
            }

            Console.WriteLine(result);
        }

        static async Task<string> AddMinionsAndVillainsToDatabaseAsync(SqlConnection connection, SqlTransaction transaction, string[] minionInfo, string[] villainInfo)
        {
            string minionTownName = minionInfo[3];

            string villainName = villainInfo[1];

            StringBuilder sb = new StringBuilder();

            int townId = await AddTownToDbAsync(connection, transaction, sb, minionTownName);
            int villainId = await AddVillainToDbAsync(connection, transaction, sb, villainName);
            int minionId = await AddMinionToDbAsync(connection, transaction, sb, minionInfo, villainName, townId);
            await AddMinionIdAndVillainIdToMinionsVillains(connection, transaction, minionId, villainId);

            return sb.ToString().Trim();
        }

        private static async Task<int> AddTownToDbAsync(SqlConnection connection, SqlTransaction transaction, StringBuilder sb, string minionTownName)
        {
            SqlCommand selectTownCmd = new SqlCommand(SqlQueries.SELECT_TOWN, connection, transaction);
            selectTownCmd.Parameters.AddWithValue("@townName", minionTownName);

            int? townId = (int?)await selectTownCmd.ExecuteScalarAsync();

            if (!townId.HasValue)
            {
                SqlCommand addTownToDb = new SqlCommand(SqlQueries.ADD_TOWN_TO_DB, connection, transaction);
                addTownToDb.Parameters.AddWithValue("@townName", minionTownName);
                await addTownToDb.ExecuteNonQueryAsync();

                sb.AppendLine($"Town {minionTownName} was added to the database.");
                townId = await GetIdAsync(selectTownCmd);
            }

            return townId.Value;
        }

        private static async Task<int> AddVillainToDbAsync(SqlConnection connection, SqlTransaction transaction, StringBuilder sb, string villainName)
        {
            SqlCommand selectVillainCmd = new SqlCommand(SqlQueries.SELECT_VILLAIN, connection, transaction);
            selectVillainCmd.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await selectVillainCmd.ExecuteScalarAsync();

            if (!villainId.HasValue)
            {
                SqlCommand addVillainToDb = new SqlCommand(SqlQueries.ADD_VILLAIN_TO_DB, connection, transaction);
                addVillainToDb.Parameters.AddWithValue("@villainName", villainName);
                await addVillainToDb.ExecuteNonQueryAsync();

                sb.AppendLine($"Villain {villainName} was added to the database.");
                villainId = await GetIdAsync(selectVillainCmd);
            }

            return villainId.Value;
        }

        private static async Task<int> AddMinionToDbAsync(SqlConnection connection, SqlTransaction transaction, StringBuilder sb, string[] minionInfo, string villainName, int townId)
        {
            SqlCommand selectMinionCmd = new SqlCommand(SqlQueries.SELECT_MINION, connection, transaction);
            selectMinionCmd.Parameters.AddWithValue("@Name", minionInfo[1]);

            SqlCommand selectTownCmd = new SqlCommand(SqlQueries.SELECT_TOWN, connection, transaction);
            selectTownCmd.Parameters.AddWithValue("@townName", minionInfo[3]);

            SqlCommand addMinionToDb = new SqlCommand(SqlQueries.ADD_MINION_TO_DB, connection, transaction);
            addMinionToDb.Parameters.AddWithValue("@name", minionInfo[1]);
            addMinionToDb.Parameters.AddWithValue("@age", int.Parse(minionInfo[2]));
            addMinionToDb.Parameters.AddWithValue("@townId", townId);

            await addMinionToDb.ExecuteNonQueryAsync();

            sb.AppendLine($"Successfully added {minionInfo[1]} to be minion of {villainName}.");

            return await GetIdAsync(selectMinionCmd);
        }

        private static async Task AddMinionIdAndVillainIdToMinionsVillains(SqlConnection connection, SqlTransaction transaction, int minionId, int villainId)
        {
            if (!await CheckIfMinionAndVillainIdsExist(connection, transaction, minionId, villainId))
            {
                SqlCommand addMinionIdVillainId = new SqlCommand(SqlQueries.ADD_MINIONID_VILLAINID_TO_MINIONSVILLAINS, connection, transaction);
                addMinionIdVillainId.Parameters.AddWithValue("@minionId", minionId);
                addMinionIdVillainId.Parameters.AddWithValue("@villainId", villainId);
                await addMinionIdVillainId.ExecuteNonQueryAsync();
            }
        }

        private static async Task<int> GetIdAsync(SqlCommand command) => (int)await command.ExecuteScalarAsync();

        private static async Task<bool> CheckIfMinionAndVillainIdsExist(SqlConnection connection, SqlTransaction transaction, int minionId, int villainId)
        {
            SqlCommand checkPrimaryKeyExistance = new SqlCommand(SqlQueries.SELECTCOMPOSITE_PRIMARY_KEY_MINIONSVILLAINS, connection, transaction);
            checkPrimaryKeyExistance.Parameters.AddWithValue("@minionId", minionId);
            checkPrimaryKeyExistance.Parameters.AddWithValue("@villainId", villainId);

            SqlDataReader reader = await checkPrimaryKeyExistance.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }

            reader.Close();
            return false;
        }
    }
}