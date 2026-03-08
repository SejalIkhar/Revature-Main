// Import basic system classes like Console
using System;

// Import SQL Server related classes like SqlConnection, SqlCommand, SqlDataReader
using Microsoft.Data.SqlClient;

// Define a public class
public class ExecuteReaderDemo
{
    // Static method so it can be called without creating object of class
    public static void Run()
    {
        // Get connection object from helper class
        // 'using' ensures automatic disposal after method ends
        using var connection = DbConnectionHelper.GetConnection();

        // Open physical connection to SQL Server
        connection.Open();

        // SQL query to fetch all records from ADO_TABLE
        var query = "SELECT * FROM ADO_TABLE";

        // Create SqlCommand object
        // It links SQL query with open connection
        using var command = new SqlCommand(query, connection);

        // Execute SELECT query
        // ExecuteReader() returns SqlDataReader object
        using var reader = command.ExecuteReader();

        // Print heading in console
        Console.WriteLine("---- ExecuteReader Output ----");

        // Loop through each row returned by query
        while (reader.Read())
        {
            // Print column values of current row
            // reader["ColumnName"] fetches column value
            Console.WriteLine(
                $"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
    }
}