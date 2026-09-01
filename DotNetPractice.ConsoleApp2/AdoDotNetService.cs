using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPractice.ConsoleApp2
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

            string query = @"SELECT [StudentId]
      ,[StudentName]
      ,[Email]
      ,[Password]
  FROM [dbo].[Tbl_Student]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item["StudentId"]);
                Console.WriteLine(item["StudentName"]);
                Console.WriteLine(item["Email"]);
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
            string query = @"INSERT INTO [dbo].[Tbl_Student]
           ([StudentName]
           ,[Email]
           ,[Password])
VALUES
           ('Linn', 'linn@gmail.com', '12345'),
           ('Aung Aung', 'aung@gmail.com', '67890'),
           ('Su Su', 'susu@gmail.com', 'abc123');";

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
            string query = @"UPDATE [dbo].[Tbl_Student]
SET [StudentName] = 'Thiri Yugan',
    [Email] = 'thiriyugan@gmail.com',
    [Password] = 'thiri123'
WHERE [StudentName] = 'Thiri Linn';";

            SqlCommand cmd = new SqlCommand(query, connection);
            int resulte = cmd.ExecuteNonQuery();

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
            string query = @"DELETE FROM [dbo].[Tbl_Student]
WHERE [StudentName] = 'Su Su';";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

        }

        }
}
