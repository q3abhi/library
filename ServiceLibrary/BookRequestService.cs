using System;
using System.Collections;
using System.Collections.Generic;
using DalLibrary;
using ModelLibrary;

namespace ServiceLibrary
{
    public class BookRequestService : IBookRequestService
    {
        public Boolean Add(int bookid)
        {
            try
            {
                IBookService bookService = new BookService();
                Book book = bookService.GetById(bookid);

                var bookRequest = new BookRequest();
                bookRequest.Book = book;

                IList<BookRequest> bookRequestList = new List<BookRequest>();
                bookRequestList.Add(bookRequest);

                IBookRequestDal bookRequestDal = new BookRequestDal();
                Boolean status = bookRequestDal.Add(bookRequestList);
                return status;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestService, Add()");
                Console.Write(e.ToString());
                return false;
            }

        }

        public BookRequest GetByBook(int bookid)
        {
            try
            {
                IBookDal bookDal = new BookDal();
                Book book = bookDal.GetById(bookid);


                IBookRequestDal bookRequestDal = new BookRequestDal();
                BookRequest bookRequest = bookRequestDal.GetByBook(book);

                return bookRequest;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestService , GetBookById()");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<UserBookRequest> FetchAllPendingRequests()
        {
            try
            {
                IUserBookRequestDal userBookRequestDal = new UserBookRequestDal();
                IList<UserBookRequest> userBookRequestsList = userBookRequestDal.ReadAllPending();
                return userBookRequestsList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestService , FetchPendingRequests()");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<UserBookRequest> ReadAllRequestsForUser(int userid)
        {
            try
            {
                IUserBookRequestDal userBookRequestDal = new UserBookRequestDal();
                IList<UserBookRequest> userBookRequestsList = userBookRequestDal.ReadAllActiveRequestsForUser(userid);
                return userBookRequestsList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestService , ReadAllRequestsForUser()");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<UserBookRequest> DeleteBookRequestForUser(int userid, int bookid)
        {
            try
            {
                IUserBookRequestDal userBookRequestDal = new UserBookRequestDal();
                IList<UserBookRequest> userBookRequestsList = userBookRequestDal.ReadAllActiveRequestsForUser(userid);
                return userBookRequestsList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestService , DeleteBookRequestForUser()");
                Console.Write(e.ToString());
                return null;
            }
        }

        
    }
}
