namespace PrintAllMinionNames
{
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();

            SqlCommand getMinionNamesCmd = new SqlCommand
                (@"SELECT Name FROM Minions", connection);

            using SqlDataReader reader = await getMinionNamesCmd.ExecuteReaderAsync();
            List<string> minionNames = new List<string>();

            while (await reader.ReadAsync())
            {
                minionNames.Add((string)reader["Name"]);
            }

            string[] minionNamesArray = new string[minionNames.Count];
            int listCount = 0;
            int endIndex = minionNames.Count;

            for (int i = 0; i < minionNamesArray.Length; i++)
            {
                minionNamesArray[i] = minionNames[listCount++];

                if (endIndex <= listCount)
                {
                    break;
                }

                minionNamesArray[++i] = minionNames[--endIndex];
            }

            Console.WriteLine(String.Join(Environment.NewLine, minionNamesArray));
        }
    }
}