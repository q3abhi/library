using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using library.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace TestLibrary
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestUserController()
        {
            UserController ucontroller = new UserController();

 //           Assert.AreEqual(ucontroller,new UserController());

      //      Assert.AreEqual("Hello", ucontroller.Create());
            String username = "quaker";
            String password = "abhishek";

            ActionResult result = ucontroller.Login(username, password);

            Console.Write(result);


        }

    }
}
