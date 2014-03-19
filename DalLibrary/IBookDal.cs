using System;
using System.Collections.Generic;
using ModelLibrary;

namespace DalLibrary
{
    public interface IBookDal
    {
        IList<Book> GetAllBooks();
        Boolean SaveBooks(IList<Book> books);
        Book GetById(int id);
        IList<Book> SearchBook(String searchString);
    }
}