using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLibrary;
using NHibernate;

namespace ModelLibrary
{
    public class Hdal
    {
        public void MakeConnection(User user)
        {
           NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();        
           config.Configure().Configure("hibernate.cfg.xml");
           config.AddAssembly(typeof(User).Assembly);
          
           NHibernate.ISessionFactory factory = config.BuildSessionFactory();
           NHibernate.ISession session = factory.OpenSession();
     //    NHibernate.ITransaction transaction = session.BeginTransaction();
   /*      Console.Write("Saving");
           session.Save(user);   */

           IQuery iquery = session.CreateQuery("from User u where u.Username='quaker'");
           IList<User> returnUser = iquery.List<User>();
           Console.Write(returnUser[0].Age);
            
//         transaction.Commit();
           session.Close();

            
        }

    }
}
