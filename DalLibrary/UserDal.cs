using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModelLibrary;
using NHibernate.Criterion;

namespace DalLibrary
{
    public class UserDal : IUserDal
    {
        public Boolean CreateNewUser(IList<User> userList)
        {
            try
            {
                IDal<User> user = new Dal<User>();
                Boolean status = user.Save(userList);
                return status;

            }
            catch (Exception e)
            {
                Console.Write("Error at UserDal, CreateNewUser()");
                Console.Write(e.ToString());
                return false;
            }
        }

        public User ValidateUser(User user)
        {
            String query = "from User u where u.Username='" + user.Username + "' " +
                           "and u.Password='" + user.Password + "'";
            try
            {
                IDal<User> dal = new Dal<User>();

                IList<User> objectList = dal.Read(query);

                if (objectList.Count != 0)
                {
                    User returnedUser = (User) objectList.FirstOrDefault();
                    return returnedUser;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception e)
            {
                Console.Write("Error at UserDal");
                Console.Write(e.ToString());
                return null;
            }
        }

        public User FindById(int id)
        {
            String query = "from User u where u.id=" + id;

            try
            {
                IDal<User> dal = new Dal<User>();

                IList<User> objectList = dal.Read(query);

                if (objectList.Count != 0)
                {
                    User returnedUser = (User) objectList.FirstOrDefault();
                    return returnedUser;
                }

                return null;
            }

            catch (Exception e)
            {
                Console.Write("Error at UserDal, FindById");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<UserBookRequest> SearchUser(String searchString)
        {
            try
            {
 
                String searchPattern = "%" + searchString + "%";
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                NHibernate.ISession session = dal.GetSession();
                var criteriaQuery = session.CreateCriteria<UserBookRequest>("ubr")
                    .CreateAlias("ubr.User","u")
                    .CreateAlias("ubr.BookRequest","br")
                    .CreateAlias("br.Book","b")
                    .Add(Restrictions.Disjunction()
                       .Add(Restrictions.Like("u.Name", searchPattern))
                       .Add(Restrictions.Like("u.Username", searchPattern))
                       .Add(Restrictions.Like("b.Name", searchPattern)));

                IList<UserBookRequest> returnedList = dal.Search(criteriaQuery);

                return returnedList;
            }

            catch (Exception e)
            {
                Console.WriteLine("Some problem with UserDal SearchUser()");
                Console.Write(e.ToString());
                return null;
            }
        }
    }
}
