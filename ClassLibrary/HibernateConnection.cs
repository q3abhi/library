using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ModelLibrary;

namespace ClassLibrary
{
    public class HibernateConnection
    {
        public NHibernate.ISession OpenConnection()
        {
            try
            {
 
                NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();
                NHibernate.ISessionFactory factory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(@"Data Source=SL-PN-LT-0059\SQLEXPRESS;Initial Catalog=agile;Integrated Security=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                .BuildSessionFactory();
                NHibernate.ISession session = factory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                Console.Write("There was some problem opening Hibernate connection");
                Console.Write(e.ToString());
                return null;
            }

        }

        public void CloseConnection(NHibernate.ISession session)
        {
            try
            {
                session.Close();
            }
            catch (Exception e)
            {
                Console.Write("There was some problem closing hibernate session. Check if the connection is open or already closed");
                Console.Write(e.ToString());
            }
        }
    }
}
