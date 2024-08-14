using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=localhost;Database=MyFirstDB2023;Trusted_Connection=True;Trust Server Certificate=true;");

await connection.OpenAsync();

using (connection)
{
    //SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
    //int? employeesCount = (int?) await sqlCommand.ExecuteScalarAsync();

    //Console.WriteLine(employeesCount);

    //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees ORDER BY Salary DESC", connection);

    //SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

    //using (reader)
    //{
    //    while (await reader.ReadAsync())
    //    {
    //        Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}, {reader["Salary"]:F2}");
    //    }
    //}

    //SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);

    //int? employeesCount = (int?) await countCommand.ExecuteScalarAsync();

    //Console.WriteLine(employeesCount);


    string name = Console.ReadLine();
    DateTime dateOfBirth = new DateTime(2002, 10, 3);

    SqlCommand command = new SqlCommand($"INSERT INTO People (Name, Birthdate) VALUES (@name, @birthdate)", connection);
    command.Parameters.AddWithValue("@name", name);
    command.Parameters.AddWithValue("@birthdate", dateOfBirth);

    await command.ExecuteNonQueryAsync();

    SqlCommand showPersonalInfo = new SqlCommand("SELECT * FROM People", connection);

    SqlDataReader reader = await showPersonalInfo.ExecuteReaderAsync();

    using (reader)
    {
        while (await reader.ReadAsync())
        {
            Console.WriteLine($"{reader[1]}, {reader[2]}");
        }
    }



}

