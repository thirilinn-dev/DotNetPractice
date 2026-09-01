using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp3
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
            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();
            string query = @"SELECT [UserId]
      ,[Username]
      ,[Password]
  FROM [dbo].[Tbl_User]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item["UserId"]);
                Console.WriteLine(item["Username"]);
                Console.WriteLine(item["Password"]);
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
            string query = @"INSERT INTO [dbo].[Tbl_User]
           ([Username]
           ,[Password])
VALUES
           ('admin', 'admin123'),
           ('lynn', 'lynn123'),
           ('student01', 'student123');";

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

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
            string query = @"UPDATE [dbo].[Tbl_User]
SET [Username] = 'student02',
    [Password] = 'newpass123'
WHERE [Username] = 'student01';";

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

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
            string query = @"DELETE FROM [dbo].[Tbl_User]
WHERE [Username] = 'student02';";

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
        }

        }
}
