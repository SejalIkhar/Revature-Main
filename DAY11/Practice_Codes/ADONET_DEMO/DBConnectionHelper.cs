using Microsoft.Data.SqlClient;

// Define a public static class
// Static means: you cannot create object of this class
public static class DbConnectionHelper
{
    // Public static method that returns SqlConnection object
    // Static method can be called without creating object of class
    public static SqlConnection GetConnection()
    {
        var connectionString =
            "Server=localhost\\SQLEXPRESS;Database=ADODB;Trusted_Connection=True;TrustServerCertificate=True;";

        return new SqlConnection(connectionString);
    }
}