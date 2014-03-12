using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class BookRequestServiceTest
    {
        [TestMethod]
        public void TestAdd()
        {
            IBookRequestService bookRequestService = new BookRequestService();
            Boolean status = bookRequestService.Add(1);

            Assert.IsTrue(status);
        }
    }
}
