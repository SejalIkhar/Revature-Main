// Import basic system classes like Console
using System;

// Import SQL Server related classes
using Microsoft.Data.SqlClient;

// Define a public class
public class ExecuteScalarDemo
{
    // Static method so it can be called without creating object
    public static void Run()
    {
        // Get connection object from helper class
        // 'using' ensures automatic disposal
        using var connection = DbConnectionHelper.GetConnection();

        // Open physical connection to SQL Server
        connection.Open();

        // SQL query that returns a single value
        // COUNT(*) counts total rows in table
        var query = "SELECT COUNT(*) FROM ADO_TABLE";

        // Create SqlCommand object with query and open connection
        using var command = new SqlCommand(query, connection);

        // ExecuteScalar() executes query and returns first column of first row
        // Since COUNT(*) returns one number, we cast it to int
        int count = (int)command.ExecuteScalar();

        // Print result
        Console.WriteLine($"Total Customers: {count}");
    }
}