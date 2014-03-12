using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModelLibrary;

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

                if (objectList.Count!= 0)
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
                    User returnedUser = (User)objectList.FirstOrDefault();
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
    }
}
