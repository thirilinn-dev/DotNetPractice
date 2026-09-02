// See https://aka.ms/new-console-template for more information
using DotNetPractice.ConsoleApp6;

Console.WriteLine("Hello, World!");

DapperService ds = new DapperService();
//ds.Read();
//ds.Create();
//ds.Update();
ds.Delete();

Console.ReadLine();