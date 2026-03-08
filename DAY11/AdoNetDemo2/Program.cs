// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using Microsoft.Data.SqlClient;

var connectionString = "Server=localhost\\SQLEXPRESS;Database=Customer;Trusted_Connection=True;TrustServerCertificate=True;";


// Create connection
using var connection = new SqlConnection(connectionString);

try
{
    connection.Open();
    Console.WriteLine("Connection opened successfully.\n");

    // 👉 Uncomment ONE method at a time to test

    //ExecuteReader(connection);
     //ExecuteNonQuery(connection);
    // ExecuteScalar(connection);
    //SqlDataAdapterDemo(connection);
    //SqlInjectionDemo(connection);
    ParameterizedQueryDemo(connection);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
finally
{
    connection.Close();
}

//////////////////////////////////////////////////////
// 1️⃣ ExecuteReader - Read Multiple Records
//////////////////////////////////////////////////////
/*void ExecuteReader(SqlConnection connection)
{
    var query = "SELECT * FROM Customers";

    using var command = new SqlCommand(query, connection);
    using var reader = command.ExecuteReader();

    Console.WriteLine("---- Customer List ----");

    while (reader.Read())
    {
        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
}*/

//////////////////////////////////////////////////////
// 2️⃣ ExecuteNonQuery - Insert Data
//////////////////////////////////////////////////////
/*void ExecuteNonQuery(SqlConnection connection)
{
    var query = "INSERT INTO Customers (Id, Name, Age) VALUES (4, 'David', 35)";

    using var command = new SqlCommand(query, connection);
    var rows = command.ExecuteNonQuery();

    Console.WriteLine($"Rows affected: {rows}");
}*/

//////////////////////////////////////////////////////
// 3️⃣ ExecuteScalar - Get Single Value
//////////////////////////////////////////////////////
/*void ExecuteScalar(SqlConnection connection)
{
    var query = "SELECT COUNT(*) FROM Customers";

    using var command = new SqlCommand(query, connection);
    var count = (int)command.ExecuteScalar();

    Console.WriteLine($"Total Customers: {count}");
}*/

//////////////////////////////////////////////////////
// 4️⃣ SqlDataAdapter - Disconnected Model
//////////////////////////////////////////////////////
/*void SqlDataAdapterDemo(SqlConnection connection)
{
    var query = "SELECT * FROM Customers";

    using var adapter = new SqlDataAdapter(query, connection);
    var table = new DataTable();

    adapter.Fill(table);

    Console.WriteLine("---- DataAdapter Output ----");

    foreach (DataRow row in table.Rows)
    {
        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}");
    }
}*/

//////////////////////////////////////////////////////
// 5️⃣ SQL Injection Demo (Unsafe)
//////////////////////////////////////////////////////
/*void SqlInjectionDemo(SqlConnection connection)
{
    var userInput = "1 OR 1=1";
    var query = $"SELECT * FROM Customers WHERE Id = {userInput}";

    using var command = new SqlCommand(query, connection);
    using var reader = command.ExecuteReader();

    Console.WriteLine("---- SQL Injection Result ----");

    while (reader.Read())
    {
        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
}*/

//////////////////////////////////////////////////////
// 6️⃣ Parameterized Query (Safe)
//////////////////////////////////////////////////////
void ParameterizedQueryDemo(SqlConnection connection)
{
    var name = "John";

    using var command = new SqlCommand(
        "SELECT * FROM Customers WHERE Name = @Name",
        connection);

    command.Parameters.AddWithValue("@Name", name);

    using var reader = command.ExecuteReader();

    Console.WriteLine("---- Parameterized Query Result ----");

    while (reader.Read())
    {
        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
    }
}