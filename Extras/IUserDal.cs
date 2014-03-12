using System;
using System.Data.SqlClient;
using ModelLibrary;

namespace DalLibrary
{
    public interface IUserDal
    {
        int Create(User user);
        Object[] ValidateUser(User user);
        User GetUser(User user);
    }
}