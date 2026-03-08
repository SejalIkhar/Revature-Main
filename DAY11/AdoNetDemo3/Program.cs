// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             @"Server=localhost\SQLEXPRESS;
//               Database=Revature;
//               Trusted_Connection=True;
//               TrustServerCertificate=True;";

//         try
//         {
//             using SqlConnection connection = new SqlConnection(connectionString);
//             connection.Open();
//             Console.WriteLine("Connection opened successfully.\n");

//             string query = "SELECT Id, Name, Age FROM dbo.ADO_table";

//             using SqlCommand command = new SqlCommand(query, connection);
//             using SqlDataReader reader = command.ExecuteReader();

//             Console.WriteLine("ID\tName\tAge");
//             Console.WriteLine("----------------------");

//             while (reader.Read())
//             {
//                 int id = reader.GetInt32(0);
//                 string name = reader.GetString(1);
//                 int age = reader.GetInt32(2);

//                 Console.WriteLine($"{id}\t{name}\t{age}");
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Error: " + ex.Message);
//         }

//         Console.ReadLine();
//     }

//     //using ExecuteScaler

// }

using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string (CRM database)
        string connectionString =
            @"Server=localhost\SQLEXPRESS;
              Database=Revature;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        //  try
        //  {
        //     // Open connection
        //     // using SqlConnection connection = new SqlConnection(connectionString);
        //     // connection.Open();
        //     // Console.WriteLine("Connection opened successfully.");

        //    // SqlDataAdapterDemo(connection);
        //     //InsertStudentDemo(connection);
        //  }
        //  catch(Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     return;
        // }

        // void SqlInjectionDemo(SqlConnection connection)
        // {
        //     var userInput="1 or 1=1";
        //     var query=$"SELECT * FROM  StudentInfo where id={userInput}";

        //     using var command= new SqlCommand(query, connection);
        //     try
        //     {
        //         using var Reader=command.ExecuteReader();
        //         while(Reader.Read())
        //         {
        //             Console.WriteLine($"id:{Reader["id"]},");
        //         }
        //     }
        //     catch(Exception ex)
        //     {
                
        //     }
        // }
        

        // void InsertStudentDemo(SqlConnection connection)
        // {
        //     var dataSet = new DataSet();
        //     var selectQuery = "SELECT * FROM StudentInfo";
        //     using var selectCommand = new SqlCommand(selectQuery, connection);
        //     using var adapter = new SqlDataAdapter(selectCommand);
        //     adapter.Fill(dataSet, "StudentInfo");

        //     var dataTable = dataSet.Tables["StudentInfo"];

        //     var newRow = dataTable.NewRow();
        //     newRow["id"] = 2;
        //     newRow["sname"] = "New Student";
        //     newRow["age"] = 28;

        //     dataTable.Rows.Add(newRow);



        //     adapter.InsertCommand = new SqlCommand("INSERT INTO StudentInfo (id, sname, age) VALUES (@id, @sname, @age)", connection);

        //     adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 6, "id");
        //     adapter.InsertCommand.Parameters.Add("@sname", SqlDbType.NVarChar, 50, "sname");
        //     adapter.InsertCommand.Parameters.Add("@age", SqlDbType.Int, 0, "age");

        //     dataSet.AcceptChanges();
        // }

        // void  SqlDataAdapterDemo(SqlConnection connection)
        // {
        //     var query="SELECT * FROM StudentInfo";
        //     SqlCommand sqlCommand=new (query, connection);
        //     using var selectAllStudentsCommand=sqlCommand;
        //     using var adapter=new SqlDataAdapter(selectAllStudentsCommand);
        //     var studentsDataTable=new DataTable();

        //     adapter.Fill(studentsDataTable);

        //     foreach(DataRow row in studentsDataTable.Rows)
        //     {
        //         Console.WriteLine($"Id:{row["id"]}, Name:{row["sname"]}, Age:{row["age"]}");
        //     }
        // }
            // SQL Query
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection opened successfully.");
            string query =
                "SELECT ID  , Name, Salary FROM ADO_table WHERE Salary > @Salary";
            // Create command
            using SqlCommand command = new SqlCommand(query, connection);

            // Execute reader
            using SqlDataReader reader = command.ExecuteReader();

    //         Console.WriteLine("id\tsname\tage");
    //         Console.WriteLine("-------------------");

    //         while (reader.Read())
    //         {
    //             int id = reader.GetInt32(0);
    //             string name = reader.GetString(1);
    //             int age = reader.GetInt32(2);

    //             Console.WriteLine($"{id}\t{name}\t{age}");
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Error: " + ex.Message);
    //     }

    //     Console.ReadLine();
    // }

    // //using ExecuteScaler
    command.Parameters.AddWithValue("@Salary", 20000);
    int count=(int)command.ExecuteScalar();
    Console.WriteLine("Students Salary > 20000:"+count);
    
    //using ExecuteReader
    //using SqlDataReader reader = command.ExecuteReader();
     Console.WriteLine("ID\name\tSalary");
    Console.WriteLine("-------------------");
    while (reader.Read())
        {
            Console.WriteLine(
                $"{reader.GetInt32(0)}\t" +
                $"{reader.GetString(1)}\t" +
                $"{reader.GetInt32(2)}");
        }

        //using ExecuteNonQeury
        // string query =
        //     "INSERT INTO StudentInfo (sname, age) VALUES (@name, @age)";

        // using SqlCommand cmd = new SqlCommand(query, connection);
        // cmd.Parameters.AddWithValue("@name", "Amit");
        // cmd.Parameters.AddWithValue("@age", 26);

        // int rows = cmd.ExecuteNonQuery();

        // Console.WriteLine("Rows inserted: " + rows);
    }
    
}
