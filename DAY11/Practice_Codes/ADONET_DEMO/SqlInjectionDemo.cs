using System;
using Microsoft.Data.SqlClient;

public class SqlInjectionDemo
{
    public static void Run()
    {
        using var connection = DbConnectionHelper.GetConnection();
        connection.Open();

        var userInput = "1 OR 1=1";
        var query = $"SELECT * FROM ADO_TABLE WHERE Id = {userInput}";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        Console.WriteLine("---- SQL Injection Result ----");

        while (reader.Read())
        {
            Console.WriteLine(
                $"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
        }
    }
}