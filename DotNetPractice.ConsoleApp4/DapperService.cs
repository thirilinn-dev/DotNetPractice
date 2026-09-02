using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp4
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

                List<dynamic> lst = db.Query<dynamic>(@"SELECT [CourseId]
      ,[CourseCode]
      ,[CourseName]
      ,[Credit]
  FROM [dbo].[Tbl_Course]").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"Id: {item.CourseId}, Code: {item.CourseCode}, Name: {item.CourseName}, Credit: {item.Credit}");
                }

            }

        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();

                int result = db.Execute(@"INSERT INTO [dbo].[Tbl_Course]
           ([CourseCode]
           ,[CourseName]
           ,[Credit])
VALUES
           ('CS101', 'Database Management System', 3),
           ('CS102', 'Data Structures and Algorithms', 3),
           ('CS103', 'Object Oriented Programming', 4);");

                Console.WriteLine($"Row Affected: {result}");

            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"UPDATE [dbo].[Tbl_Course]
SET [CourseCode] = 'CS201',
    [CourseName] = 'Advanced Database Management',
    [Credit] = 4
WHERE [CourseCode] = 'CS101';");

                Console.WriteLine($"Row Affected: {result}");

            }

        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
            {
                db.Open();
                int result = db.Execute(@"DELETE FROM [dbo].[Tbl_Course]
WHERE [CourseCode] = 'CS102';");

                Console.WriteLine($"Row Affected: {result}");
            }

        }
    }
}
