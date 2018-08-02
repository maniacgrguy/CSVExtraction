using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    class DataAccess
    {
        string connectionString = string.Empty;

        public DataAccess()
        {

        }
        public bool TestConnection(string serverName, string databaseName, string id, string password)
        {
            try
            {
                connectionString = $"Data Source={serverName};Initial Catalog={databaseName}; User id={id}; Password={password};";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    sqlConnection.Close();
                    Console.WriteLine("Successfully open and closed the connection");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection couldnot be open {ex.Message}");
                return false;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    dt = new DataTable();
                    using (SqlCommand sqlCmd = new SqlCommand(query, sqlConnection))
                    {
                        SqlDataAdapter sAdap = new SqlDataAdapter(sqlCmd);
                        sAdap.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing query " + ex.Message);
                return null;
            }
        }
    }
}
