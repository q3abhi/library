using System;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using ServiceLibrary;
using System.Collections.Generic;

namespace TestLibrary
{
    [TestClass]
    public class UserServiceTest
    {
//        [TestMethod]
        public void TestUserService()
        {
            UserService uservice = new UserService();
            User user = new User();

            user.Name = "Abhishek";
            user.Password = "Pohankar";

    //        Assert.AreEqual(user,uservice.Create("Abhishek",24,"abhi","1234"));
    } 

//          [TestMethod]
        public void TestValidateUser()
        {
            UserService service = new UserService();
            String username = "quaker";
            String password = "abhishek";

            UserDto dto = service.ValidateUser(username, password);
            String json = new JavaScriptSerializer().Serialize(dto);
            Console.Write(json);
        }

//        [TestMethod]
        public void TestGetById()
        {
            IUserService userService = new UserService();
            User user = userService.GetUserById(20);

            Assert.IsNotNull(user);

            Console.WriteLine(user.Age);
        }

        [TestMethod]
        public void TestUserSearch()
        {
            String searchString = "q3";
            IUserService userService = new UserService();
            IList<UserBookRequest> returnedList  = userService.UserSearch(searchString);
            foreach (var ubr in returnedList)
            {
                Console.WriteLine(ubr.BookRequest.Book.Name);
            }
            Assert.IsNotNull(returnedList);

        }

    }
}

