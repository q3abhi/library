using System;
using System.Collections.Generic;
using ModelLibrary;

namespace DalLibrary
{
    public interface IUserDal
    {
         User ValidateUser(User user);
         User FindById(int id);
         Boolean CreateNewUser(IList<User> userList);
    }
}