// See https://aka.ms/new-console-template for more information
using Dapper;
using DotNetPractice.ConsoleApp4;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

DapperService service = new DapperService();
//service.Read();
//service.Create();
//service.Update();
service.Delete();

Console.ReadLine();
