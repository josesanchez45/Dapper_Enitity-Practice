using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true";

IDbConnection dbConnection = new SqlConnection(connectionString);

string sqlCommand = "SELECT GETDATE()";

DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand); 

Console.WriteLine($"{rightNow}");