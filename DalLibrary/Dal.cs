using System;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary;
using ModelLibrary;
using NHibernate;

namespace DalLibrary
{
    public class Dal<T> : IDal<T>
    {
        public IList<T> Read(string query)
        {
            try
            {
                HibernateConnection connection = new HibernateConnection();
                NHibernate.ISession session = connection.OpenConnection();
                IQuery iquery = session.CreateQuery(query);
                IList<T> returnedData = iquery.List<T>();
                connection.CloseConnection(session);

                return returnedData;
            }

            catch (Exception e)
            {
                Console.Write("Error while retrieving data");
                Console.Write(e.ToString());
         
                return null;
            }           
        }


        public Boolean Save(IList<T> dataList)
        {
            try
            {
                HibernateConnection connection = new HibernateConnection();
                NHibernate.ISession session = connection.OpenConnection();
                NHibernate.ITransaction transaction = session.BeginTransaction();

                foreach (T data in dataList)
                {
                    session.SaveOrUpdate(data);
                    transaction.Commit();
                }
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Transaction was rolled back due to some reasons");
                Console.Write(e.ToString());
                return false;
            }
       }

        protected NHibernate.ISession GetSession()
        {
            try
            {
                HibernateConnection connection = new HibernateConnection();
                NHibernate.ISession session = connection.OpenConnection();
                return session;
            }
            catch (Exception e)
            {
                Console.WriteLine("Session object could not be created");
                Console.Write(e.ToString());
                return null;
            }


        }
    }
}
