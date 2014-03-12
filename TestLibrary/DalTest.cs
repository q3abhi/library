using System;
using System.Collections;
using System.Collections.Generic;
using DalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace TestLibrary
{
    [TestClass]
    public class DalTest
    {
   //     [TestMethod]
        public void TestDal()
        {
            Dal<User> dal = new Dal<User>();
            String query="SELECT * FROM lib_user " +
                           "WHERE username='q3_abhi' AND password='abhishek'";
            dal.Read(query);

        }

        [TestMethod]
        public void TestSave()
        {
            Dal<Book> dal = new Dal<Book>();
            Book book = new Book();

            book.Author = "Abhishek";
            book.Copies = 2;
            book.Description = "Nice book";
            book.Name = "New book";
            book.Price = 500;
            book.Publisher = "Mehta Publisher";   

            IList<Book> books = new List<Book>();  
            books.Add(book);

            Assert.IsTrue(dal.Save(books));
        }
    }
}
