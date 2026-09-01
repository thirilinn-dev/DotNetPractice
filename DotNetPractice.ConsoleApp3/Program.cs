// See https://aka.ms/new-console-template for more information
using DotNetPractice.ConsoleApp3;

Console.WriteLine("Hello, World!");

AdoDotNetService service = new AdoDotNetService();
//service.Read();
//service.Create();
//service.Update();
service.Delete();

Console.ReadLine();