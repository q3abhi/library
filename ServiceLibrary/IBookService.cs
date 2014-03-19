using System;
using System.Collections.Generic;
using ModelLibrary;

namespace ServiceLibrary
{
    public interface IBookService
    {
        IList<Book> GetAllBooks();
        Boolean SaveBooks(Book book);
        Book GetById(int id);
        Boolean BookRequest(Book book, User user);
        IList<Book> BookSearch(String searchString);
    }
}