using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLibrary
{
    [TestClass]
    public class DbaseConnectionTest
    {
  /*      public void TestDbConnectionTest()
        {
            String properties = "Data Source=localhost\\SQLExpress;Initial Catalog=agile;Trusted_Connection=true;";
            DbaseConnection connection = new DbaseConnection();
            SqlConnection connect = connection.OpenConnection(properties);

            Assert.AreEqual(connect,connection.OpenConnection(properties));

        }*/

        [TestMethod]
        public void TestOpenConnection()
        {
            String properties = "Data Source=localhost\\SQLExpress;Initial Catalog=agile;Trusted_Connection=true;";
            DbaseConnection connection = new DbaseConnection();
            SqlConnection co = null;
            try
            {
               co = connection.OpenConnection(properties);
                Assert.Fail("Should Fail");
                connection.CloseConnection(co);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                connection.CloseConnection(co);
            }
        }

        [TestMethod]
        public void TestCloseConnection()
        {
            
        }

        [TestMethod]
        public void GetConnectionProperties()
        {
            DbaseConnection connection = new DbaseConnection();
            

            String properties = "Abhishek";

            Assert.AreEqual(properties,connection.GetConnectionProperties());
        }
    }
}
