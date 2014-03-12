using System;
using System.Collections;
using System.Collections.Generic;
using DalLibrary;
using ModelLibrary;

namespace ServiceLibrary
{
    public class UserService : IUserService
    {
  
        public Boolean Create(User user)
        {
            try
            {

                IList<User> userlist = new List<User>();
                userlist.Add(user);

                IUserDal userDal = new UserDal();
                Boolean status = userDal.CreateNewUser(userlist);
                return status;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error at UserService , CreateNewUser");
                Console.Write(e.ToString());
                return false;
            }


        }


        public User GetUser(string username, string password)
        {
            User user = new User();

            user.Username = username;
            user.Password = password;

            IUserDal userDal = new UserDal();
     //       Object[] values = userDal.ValidateUser(user);

            return user;
        }

        public UserDto ValidateUser(string username, string password)
        {
            User user = new User();

            user.Username = username;
            user.Password = password;

            IUserDal userdal = new UserDal();
            User returnedUser = userdal.ValidateUser(user);


            if (returnedUser == null)
            {
                return null;
            }
            else
            {
                IPrepareUserDto prepareUserDto = new PrepareUserDto();
                UserDto userdto = prepareUserDto.Prepare(returnedUser);
                return userdto;
            }

        }

        public User Update()
        {
            User user = new User();

            return user;
        }

        public User GetUserById(int id)
        {

            IUserDal userDal = new UserDal();
            User user = userDal.FindById(id);

            return user;            
        }
    }
}
