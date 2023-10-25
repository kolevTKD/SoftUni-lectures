namespace ChangeTownNamesCasing
{
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string inputCountry = Console.ReadLine();

            using SqlConnection connection = new SqlConnection("Server=localhost;Database=MinionsDB;Trusted_Connection=True;Trust Server Certificate=true;");
            await connection.OpenAsync();
            SqlTransaction transaction = connection.BeginTransaction();

            List<string> towns = new List<string>();
            string output = String.Empty;

            try
            {
                output = await UpdateTownsToUpperAsync(connection, transaction, inputCountry);
                await GetUpdatedCountriesAsync(connection, transaction, towns, inputCountry);
                transaction.Commit();
            }
            catch(Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(output);
            Console.WriteLine($"[{String.Join(", ", towns)}]");
        }

        private static async Task<string> UpdateTownsToUpperAsync(SqlConnection connection, SqlTransaction transaction, string inputCountry)
        {
            SqlCommand updateTownsToUpperCmd = new SqlCommand
                (@"UPDATE Towns
                      SET Name = UPPER(Name)
                    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection, transaction);
            updateTownsToUpperCmd.Parameters.AddWithValue("@countryName", inputCountry);

            await updateTownsToUpperCmd.ExecuteNonQueryAsync();
            int townsCount = await updateTownsToUpperCmd.ExecuteNonQueryAsync();

            return $"{townsCount} town names were affected.";
        }

        private static async Task GetUpdatedCountriesAsync(SqlConnection connection, SqlTransaction transaction, List<string> towns, string inputCountry)
        {
            SqlCommand getTownsCmd = new SqlCommand
                (@" SELECT t.Name 
                      FROM Towns as t
                      JOIN Countries AS c ON c.Id = t.CountryCode
                     WHERE c.Name = @countryName", connection, transaction);
            getTownsCmd.Parameters.AddWithValue("@countryName", inputCountry);



            using SqlDataReader reader = await getTownsCmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                Console.WriteLine("No town names were affected.");
                await reader.CloseAsync();
                transaction.Rollback();
                Environment.Exit(0);
            }

            while (await reader.ReadAsync())
            {
                towns.Add(reader["Name"].ToString());
            }

            await reader.CloseAsync();
        }
    }
}