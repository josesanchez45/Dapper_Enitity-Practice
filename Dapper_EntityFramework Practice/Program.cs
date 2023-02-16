﻿using Dapper;
using Dapper_EntityFramework_Practice;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true";

IDbConnection dbConnection = new SqlConnection(connectionString);

string sqlCommand = "SELECT GETDATE()";

DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand); 

Console.WriteLine($"Current Date and time: {rightNow}");

var myComputer = new Computer();
{
    myComputer.Motherboard = "Z690";
    myComputer.HasWifi = true;
    myComputer.HasLTE = true;
    myComputer.ReleaseDate = DateTime.Now;
    myComputer.Price = 943.87m;
    myComputer.VideoCard = "RTX 2060";

};


string sql = @"INSERT INTO TutorialAppSchema.Computer(
    Motherboard,
    HasWifi,
    HasLTE,
    ReleaseDate,
    Price,
    VideoCard
)VALUES ('"+myComputer.Motherboard 
+ "','" + myComputer.HasWifi
+ "','" + myComputer.HasLTE
+ "','" + myComputer.ReleaseDate
+ "','" + myComputer.Price
+ "','" + myComputer.VideoCard

+ "')";

Console.WriteLine(sql); 

var result= dbConnection.Execute(sql);

Console.WriteLine(result.ToString());

