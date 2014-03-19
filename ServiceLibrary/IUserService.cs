using System;
using System.Collections.Generic;
using ModelLibrary;

namespace ServiceLibrary
{
    public interface IUserService
    {
        Boolean Create(User user);
        UserDto ValidateUser(String username, String password);
        User GetUser(string username, string password);
        User GetUserById(int id);
        IList<UserBookRequest> UserSearch(String searchString);
    }
}