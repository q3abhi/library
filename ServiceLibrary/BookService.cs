using System;
using System.Collections;
using System.Collections.Generic;
using DalLibrary;
using ModelLibrary;

namespace ServiceLibrary
{
    public class BookService : IBookService
    {
        public IList<Book> GetAllBooks()
        {
            IBookDal bookdal = new BookDal();
            IList<Book> books = bookdal.GetAllBooks();

            if (books.Count != 0)
            {
                return books;
            }
            else
            {
                return null;
            }
        }

        public bool SaveBooks(Book book)
        {
            try
            {
                IBookDal bookdal = new BookDal();
                IList<Book> books = new List<Book>();
                books.Add(book);
                Boolean status = bookdal.SaveBooks(books);
                return status;
            }

            catch (Exception e)
            {
                Console.WriteLine("Book service crashed");
                Console.Write(e.ToString());
                return false;
            }

        }

        public Boolean BookRequest(Book book, User user)
        {
            try
            {
                IList<User> users = new List<User>();
                users.Add(user);
   //             book.Users = users;

                IList<Book> books = new List<Book>();
                books.Add(book);

                IBookDal bookdal = new BookDal();
                Boolean status = bookdal.SaveBooks(books);

                return status;
            }

            catch (Exception e)
            {
                Console.WriteLine("Some sort of error in BookService, BookRequest()");
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public Book GetById(int id)
        {
            try
            {
                IBookDal bookdal = new BookDal();
                Book book = bookdal.GetById(id);

                if (book!= null)
                {
                    return book;
                }
                return null;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in BookService,getbyId");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<Book> BookSearch(String searchString)
        {
            try
            {
                IBookDal bookDal = new BookDal();
                IList<Book> returnedBookList = bookDal.SearchBook(searchString);
                return returnedBookList;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookService,BookSearch()");
                Console.Write(e.ToString());
                return null;
            }
        }
    }
}
    

