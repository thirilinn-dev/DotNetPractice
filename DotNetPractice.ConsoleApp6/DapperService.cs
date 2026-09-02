using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp6
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
            using(IDbConnection connection = new SqlConnection(sb.ConnectionString))
            {
                connection.Open();
                List<dynamic> lst = connection.Query<dynamic>(@"SELECT [UserId]
      ,[Username]
      ,[Password]
  FROM [dbo].[Tbl_User]").ToList();

                foreach (var item in lst)
                {
                    Console.WriteLine($"Id: {item.UserId}, Name: {item.Username}, Password: {item.Password}");
                }
            }
        }

        public void Create()
        {
            using(IDbConnection connection = new SqlConnection( sb.ConnectionString))
            {
                connection.Open();
                int result = connection.Execute(@"INSERT INTO [dbo].[Tbl_User]
           ([Username]
           ,[Password])
VALUES
           ('admin', 'admin123'),
           ('lynn', 'lynn123'),
           ('student01', 'student123');");

                Console.WriteLine($"Row affected: {result}");
            }
        }

        public void Update()
        {
            using(IDbConnection connection = new SqlConnection(sb.ConnectionString))
            {
                connection.Open();

                int result = connection.Execute(@"UPDATE [dbo].[Tbl_User]
SET [Username] = 'student02',
    [Password] = 'newpass123'
WHERE [Username] = 'student01';");

                Console.WriteLine("row affected: " + result);
            }
        }

        public void Delete()
        {
            using( IDbConnection connection = new SqlConnection(sb.ConnectionString) )
            {
                connection.Open();

                int result = connection.Execute(@"DELETE FROM [dbo].[Tbl_User]
WHERE [Username] = 'admin';");

                Console.WriteLine($"row affected: {result}");
            }
        }
    }
}
