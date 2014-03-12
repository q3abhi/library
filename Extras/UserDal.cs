/* using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ModelLibrary;


namespace Extras
{
    public class UserDal : IUserDal
    {
        public int Create(User user)
        {
            String query = "INSERT INTO lib_user(name,age,username,password)" +
                           "VALUES('" + user.Name + "'," + user._age + ",'" + user.Username + "','" + user.Password +
                           "')";

            IDal dal = new Dal();
            int rowsAffected = dal.Create(query);

            return rowsAffected;
        }

        public Object[] ValidateUser(User user)
        {
            String query = "SELECT username FROM lib_user " +
                           "WHERE username='" + user.Username + "' AND password='" + user.Password + "'";

            IDal dal = new Dal();
            Object[] values = dal.Read(query);

            return values;

        }

        public User GetUser(User user)
        {
            return null;
        }
    }
}  */
