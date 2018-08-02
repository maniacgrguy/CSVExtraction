using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
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
    }
}
