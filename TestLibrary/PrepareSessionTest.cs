using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class PrepareSessionTest
    {
        [TestMethod]
        public void TestPrepare()
        {
            IPrepareSession preSession = new PrepareSession();
            String username = "quaker";
            String password = "abhishek";
            
            UserService service = new UserService();

            UserDto dto = service.ValidateUser(username, password);

            Session session = preSession.Prepare(dto);

            Console.Write(dto.Name);

            Console.Write(session.Name);

            Assert.IsNotNull(session, "Should not be null");


        }
    }
}
