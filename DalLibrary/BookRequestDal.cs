using System;
using System.Collections.Generic;
using System.Linq;
using ModelLibrary;

namespace DalLibrary
{
    public class BookRequestDal : IBookRequestDal
    {
        public Boolean Add(IList<BookRequest> bookRequestList)
        {
            try
            {
                IDal<BookRequest> dal = new Dal<BookRequest>();
                Boolean status = dal.Save(bookRequestList);

                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequest Dal , Add()");
                Console.Write(e.ToString());
                return false;
            }
        }

        public BookRequest GetByBook(Book book)
        {
            try
            {
                String query = "From BookRequest b where b.Book.Id=" + book.Id;

                IDal<BookRequest> bookRequest = new Dal<BookRequest>();
                IList<BookRequest> bookRequests = bookRequest.Read(query);

                BookRequest returnedBookRequest = bookRequests.FirstOrDefault();

                return returnedBookRequest;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequest Dal , GetByBook()");
                Console.Write(e.ToString());
                return null;
            }    
        }


        public IList<BookRequest> GetByUserId(int userId)
        {
            return null;
        } 
    }
}
