using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace ModelLibrary
{
    class FluentDal
    {
        public void MakeConnnection()
        {
      //      NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();
     //       config.Configure().Configure("hibernate.cfg.xml");
     //       config.AddAssembly(typeof(User).Assembly);

             Console.Write("Hello");
             NHibernate.ISessionFactory factory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008
            .ConnectionString(@"Data Source=SL-PN-LT-0059\SQLEXPRESS;Initial Catalog=agile;Integrated Security=True;"))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
            .BuildSessionFactory();

            //NHibernate.ISessionFactory factory = config.BuildSessionFactory();
              NHibernate.ISession session = factory.OpenSession();
            // NHibernate.ITransaction transaction = session.BeginTransaction();
            /* Console.Write("Saving");
               session.Save(user);   */

            IQuery iquery = session.CreateQuery("from User u where u.Username='quaker'");
            IList<User> returnUser = iquery.List<User>();
            Console.Write(returnUser[0].Age);


            //         transaction.Commit();
            session.Close(); 
        }
        }

}
