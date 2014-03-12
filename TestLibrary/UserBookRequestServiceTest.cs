using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class UserBookRequestServiceTest
    {
//        [TestMethod]
        public void TestAdd()
        {
            IUserBookRequestService userBookRequestService = new UserBookRequestService();
            Boolean status = userBookRequestService.Add(23, 1);

            Assert.IsTrue(status);

        }

        [TestMethod]
        public void TestDeleteBookRequestForUser()
        {
            IUserBookRequestService userBookRequestService = new UserBookRequestService();
            Boolean status = userBookRequestService.DeleteBookRequestForUser(11);
            Assert.IsTrue(status);
        }
    }
}
