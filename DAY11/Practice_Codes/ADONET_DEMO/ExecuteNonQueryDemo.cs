// Import basic system classes like Console
using System;

// Import SQL Server related classes
using Microsoft.Data.SqlClient;

// Define a public class
public class ExecuteNonQueryDemo
{
    // Static method so we can call it without creating object
    public static void Run()
    {
        // Get database connection from helper class
        // 'using' ensures automatic disposal (connection will close automatically)
        using var connection = DbConnectionHelper.GetConnection();

        // Open physical connection to SQL Server
        connection.Open();

        // SQL INSERT query to add a new record into ADO_TABLE
        var query = "INSERT INTO ADO_TABLE (Id, Name, Age) VALUES (4, 'David', 35)";

        // Create SqlCommand object with query and open connection
        using var command = new SqlCommand(query, connection);

        // ExecuteNonQuery is used for INSERT, UPDATE, DELETE
        // It returns number of rows affected
        int rows = command.ExecuteNonQuery();

        // Print how many rows were inserted
        Console.WriteLine($"Rows affected: {rows}");
    }
}