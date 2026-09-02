// See https://aka.ms/new-console-template for more information
using DotNetPractice.ConsoleApp5;

Console.WriteLine("Hello, World!");

DapperService service = new DapperService();
//service.Read();
//service.Create();
//service.Update();
service.Delete();

Console.ReadLine();