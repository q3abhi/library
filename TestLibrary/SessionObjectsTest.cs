using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class SessionObjectsTest
    {
        [TestMethod]
        public Session TestCreateSession()
        {
            IPrepareSession preSession = new PrepareSession();
            String username = "quaker";
            String password = "abhishek";
            UserService service = new UserService();
            UserDto dto = service.ValidateUser(username, password);
            SessionObjects sessionObjects = SessionObjects.CreateInstance();
            Session session = sessionObjects.CreateSession(dto);

            Console.WriteLine(session.Age);
            

            Assert.IsNotNull(session);
            return session;
        }

        [TestMethod]
        public void TestGetSession()
        {
            SessionObjects sessionObjects = SessionObjects.CreateInstance();
            Session session = sessionObjects.GetSession(23);

            Assert.IsNotNull(session);

        }

        [TestMethod]
        public void TestDeleteSession()
        {
            SessionObjects sessionObjects = SessionObjects.CreateInstance();
            Session session = TestCreateSession();
   //         Boolean status = sessionObjects.DeleteSession(session);

 //           Assert.IsTrue(status);

        }
    }
}
