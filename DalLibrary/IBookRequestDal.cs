using System;
using System.Collections.Generic;
using ModelLibrary;

namespace DalLibrary
{
    public interface IBookRequestDal
    {
        Boolean Add(IList<BookRequest> bookRequestList);
        BookRequest GetByBook(Book book);
        
    }
}