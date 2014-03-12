using System;
using System.Collections.Generic;
using System.Linq;
using ModelLibrary;
using NHibernate;

namespace DalLibrary
{
    public class BookDal : IBookDal
    {
        public IList<Book> GetAllBooks()
        {
            String query = "from Book";

            try
            {
                IDal<Book> dal = new Dal<Book>();

                IList<Book> objectList = dal.Read(query);

                if (objectList.Count!= 0)
                {
                    IList<Book> returnedBooks = (IList<Book>) objectList;

                    return returnedBooks;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Some problem with BookDal getAllBooks()");
                Console.Write(e.ToString());
                return null;
            }          
        }

        public bool SaveBooks(IList<Book> books)
        {
            try
            {
                IDal<Book> dal = new Dal<Book>();
                bool status = dal.Save(books);
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine("Save bookdal has crashed");
                return false;
            }

            
        }

        public Book GetById(int id)
        {
            String query = "from Book b where b.id="+id;

            try
            {
                IDal<Book> dal = new Dal<Book>();

                IList<Book> objectList = dal.Read(query);

                if (objectList.Count != 0)
                {
                    Book returnedBook = objectList.FirstOrDefault();

                    return returnedBook;
                }

                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Some problem with BookDal getAllBooks()");
                Console.Write(e.ToString());
                return null;
            }          
            
        }
    }
}
