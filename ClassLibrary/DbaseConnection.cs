using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class DbaseConnection
    {
        // Open the connection with the specified properties
        public SqlConnection OpenConnection(String properties)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(properties);
                myConnection.Open();
                return myConnection;
            }

            catch (Exception e)
            {
                Console.Write("Error opening connection");
                Console.Write(e.ToString());
                return null;
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.Write("Unable to close connection. Check if the connection is already closed");
                Console.Write(e.ToString());
            }            
        }

        public String GetConnectionProperties()
        {
            string properties = "Data Source=localhost\\SQLExpress;Initial Catalog=agile;Trusted_Connection=true;";

            return properties;
        }
    }
}
