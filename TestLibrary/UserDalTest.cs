using System;
using System.Collections;
using System.Security.Permissions;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace TestLibrary
{
    [TestClass]
    public class UserDalTest
    {
 //       [TestMethod]
        public void TestUserDal()
        {
           UserDal uDal = new UserDal();
   
            User user = new User();
 
            user.Username = "quaker";
            user.Password = "abhishek";

            User u = uDal.ValidateUser(user);
            IList<Membership> membership = u.Memberships;
            IList<Role> role = u.Roles;
            IList<Token> token = role[0].Tokens;

            Membership m = membership[0];
            Role r = role[0];
            Token t = token[0];

            Console.WriteLine("Membership : "+m.Name);
            Console.WriteLine("Role : "+r.Name);
            Console.WriteLine("Token : "+t.Name);

    //      Assert.AreEqual(1,uDal.Create(user));
        }

        [TestMethod]
        public void TestFindById()
        {
            IUserDal uDal = new UserDal();
            User user = uDal.FindById(20);
            Console.WriteLine(user.Name);
            Assert.IsNotNull(user);
        }
    }
}
