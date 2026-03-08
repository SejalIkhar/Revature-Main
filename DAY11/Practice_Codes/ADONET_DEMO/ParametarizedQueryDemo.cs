// Import basic system classes
using System;

// Import SQL Server related classes
using Microsoft.Data.SqlClient;

// Define a public class
public class ParameterizedQueryDemo
{
    // Static method so it can be called without creating object
    public static void Run()
    {
        // Get connection object from helper class
        // 'using' ensures automatic cleanup
        using var connection = DbConnectionHelper.GetConnection();

        // Open physical connection to SQL Server
        connection.Open();

        // SQL query with parameter placeholder (@Name)
        var query = "SELECT * FROM ADO_TABLE WHERE Name = @Name";

        // Create SqlCommand object
        using var command = new SqlCommand(query, connection);

        // Add parameter value to prevent SQL Injection
        // @Name in query gets replaced safely with "John"
        command.Parameters.AddWithValue("@Name", "John");

        // Execute SELECT query and get result set
        using var reader = command.ExecuteReader();

        Console.WriteLine("---- Parameterized Query Result ----");

        // Read each row returned
        while (reader.Read())
        {
            Console.WriteLine(
                $"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
    }
}