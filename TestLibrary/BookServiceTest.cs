﻿using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class BookServiceTest
    {
//        [TestMethod]
        public void TestGetAllBooks()
        {
            IBookService bookservice = new BookService();
            
            Assert.IsNotNull(bookservice.GetAllBooks());

  //          Assert.IsInstanceOfType(bookservice.GetAllBooks());
        }

        [TestMethod]
        public void TestBookRequest()
        {
            IBookService bookService = new BookService();
            Book book = bookService.GetById(15);
            IUserService userService = new UserService();
            User user = userService.GetUserById(20);

            Boolean status = bookService.BookRequest(book, user);

            Assert.IsTrue(status);
        }
    }
}