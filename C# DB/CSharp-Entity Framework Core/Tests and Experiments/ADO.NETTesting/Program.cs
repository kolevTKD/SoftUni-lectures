using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=SoftUni;Trusted_Connection=True;Trust Server Certificate=true;");

connection.Open();
using (connection)
{
    SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE DepartmentID = 7", connection);
    //int? peopleCount = (int?) await command.ExecuteScalarAsync();

    //Console.WriteLine($"Employees count: {peopleCount}");

    SqlDataReader reader = await command.ExecuteReaderAsync();
    using (reader)
    {
        while (reader.Read())
        {
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader[2];
            decimal salary = (decimal)reader["Salary"];

            Console.WriteLine("{0} {1} - {2}", firstName, lastName, salary);
        }
    }
}
