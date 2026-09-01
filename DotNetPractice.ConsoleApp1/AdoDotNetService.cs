using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp1
{
    internal class AdoDotNetService
    {
        public void Read()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNetPractice",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };

            Console.WriteLine("Connection String: " + sb.ConnectionString);

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            Console.WriteLine("Connection opening...");
            connection.Open();
            Console.WriteLine("Connection opened successfully.");

            string query = @"SELECT [CourseId]
      ,[CourseCode]
      ,[CourseName]
      ,[Credit]
  FROM [dbo].[Tbl_Course]
";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closed successfully.");

            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item["CourseId"]);
                Console.WriteLine(item["CourseCode"]);
                Console.WriteLine(item["CourseName"]);
                Console.WriteLine(item["Credit"]);
            }
        }

        public void Create()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNetPractice",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Course]
           ([CourseCode]
           ,[CourseName]
           ,[Credit])
VALUES
           ('CS101', 'Database Management System', 3),
           ('CS102', 'Data Structures and Algorithms', 3),
           ('CS103', 'Object Oriented Programming', 4);";

            SqlCommand cmd = new SqlCommand(query, connection);
            int rowsAffected = cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Update()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNetPractice",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Course]
SET [CourseCode] = 'CS201',
    [CourseName] = 'Advanced Database Management',
    [Credit] = 4
WHERE [CourseCode] = 'CS101';";

            SqlCommand cmd = new SqlCommand(query, connection);
            int rowsAffected = cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNetPractice",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Course]
WHERE [CourseCode] = 'CSE-015';";

            SqlCommand cmd = new SqlCommand(query, connection);
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
        }

        }

}
