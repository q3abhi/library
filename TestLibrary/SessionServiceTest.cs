using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class SessionServiceTest
    {
        [TestMethod]
        public void TestCreateUser()
        {
            String username = "quaker";
            String password = "abhishek";
            UserService service = new UserService();
            UserDto dto = service.ValidateUser(username, password);
            SessionService sessionService = new SessionService();
            Session session = sessionService.CreateSession(dto);

            Console.WriteLine(session.Name);
        }
    }
}
