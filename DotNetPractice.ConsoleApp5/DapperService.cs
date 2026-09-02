using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp5
{
    internal class DapperService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetPractice",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();

                List<dynamic> lst = db.Query<dynamic>(@"SELECT [StudentId]
      ,[StudentName]
      ,[Email]
      ,[Password]
  FROM [dbo].[Tbl_Student]").ToList();

                foreach (var item in lst)
                {
                    Console.WriteLine(item.StudentId);
                    Console.WriteLine(item.StudentName);
                    Console.WriteLine(item.Email);
                    Console.WriteLine(item.Password);
                }
            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"INSERT INTO [dbo].[Tbl_Student]
           ([StudentName]
           ,[Email]
           ,[Password])
VALUES
           ('Linn', 'linn@gmail.com', '12345'),
           ('Aung Aung', 'aung@gmail.com', '67890'),
           ('Su Su', 'susu@gmail.com', 'abc123'); ");

                Console.WriteLine("Row affected: " + result);
            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"UPDATE [dbo].[Tbl_Student]
SET [StudentName] = 'Piti',
    [Email] = 'piti@gmail.com',
    [Password] = 'piti123'
WHERE [StudentName] = 'Su Su';");

                Console.WriteLine("Row affected: " + result);
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"DELETE FROM [dbo].[Tbl_Student]
WHERE [StudentName] = 'Aung Aung';");

                Console.WriteLine($"Row affected: {result}");
            }
        }

    }
}
