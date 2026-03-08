using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class DataAdapterDemo
{
    public static void Run()
    {
        using var connection = DbConnectionHelper.GetConnection();

        var adapter = new SqlDataAdapter("SELECT * FROM ADO_TABLE", connection);

        var table = new DataTable();

        adapter.Fill(table);

        Console.WriteLine("---- DataAdapter Output ----");

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine(
                $"Id: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}");
        }
    }
}