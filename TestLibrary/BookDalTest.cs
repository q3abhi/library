using System;
using System.Collections;
using System.Collections.Generic;
using DalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace TestLibrary
{
    [TestClass]
    public class BookDalTest
    {
        [TestMethod]
        public void TestGetAllBooks()
        {
            IBookDal bookdal = new BookDal();

            IList<Book> book = bookdal.GetAllBooks();
            Console.Write(book[0].Author);
            Assert.IsNotNull(bookdal.GetAllBooks());
        }
    }
}
