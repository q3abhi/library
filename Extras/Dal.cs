/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClassLibrary;


namespace Extras
{
    public class Dal : IDal
    {
        public int Create(String query)
        {
            DbaseConnection dbconnection = new DbaseConnection();
            String properties = dbconnection.GetConnectionProperties();
            SqlConnection sqlConnection = dbconnection.OpenConnection(properties);

            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int rowsAffected = command.ExecuteNonQuery();
                dbconnection.CloseConnection(sqlConnection);
                return rowsAffected;
            }

            catch (Exception e)
            {
                Console.Write("Error executing query");
                Console.Write(e.ToString());
                dbconnection.CloseConnection(sqlConnection);
                return -1;
            }      
        }

        public Object[] Read(string query)
        {
            DbaseConnection dbconnection = new DbaseConnection();
            String properties = dbconnection.GetConnectionProperties();
            SqlConnection sqlConnection = dbconnection.OpenConnection(properties);

            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                int columnCount = reader.FieldCount;
                Object[] values = new object[columnCount];
                String[] valueNames = new string[columnCount];
                int counter = 0;

                while (reader.Read())
                {
                    int x = reader.GetValues(values);
                    for (int i = 0; i < valueNames.Length; i++)
                    {
                        valueNames[i] = reader.GetName(i);
                    }
                              
                }
                

                for (int count = 0; count < values.Length; count++)
                {
                    Console.WriteLine(valueNames[count]+" "+values[count].ToString());
                }

                dbconnection.CloseConnection(sqlConnection);
                return values;
            }

            catch (Exception e)
            {
                Console.Write("Problem with the database connectivity");
                Console.Write(e.ToString());
                dbconnection.CloseConnection(sqlConnection);
                return null;
            }   
        }

    }
} */
