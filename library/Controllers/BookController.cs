using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ModelLibrary;
using ServiceLibrary;

namespace library.Controllers
{
    public class BookController : Controller
    {
        SessionObjects sessionObj = SessionObjects.CreateInstance();
  
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBooksPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBooks(Book book)
        {
            try
            {
                IBookService service = new BookService();
                book.ToBeIssued = book.Copies;
                Boolean status = service.SaveBooks(book);

                return Content(status.Equals(true) ? "Saved !" : "Error saving book. Please try after sometime");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Book Controller");
                Console.Write(e.ToString());
                return View();
            }           
        }

        [HttpGet]
        public ActionResult ViewBooks(String id)
        {
            try
            {
                int code = Convert.ToInt32(id);
                Boolean sessionState = sessionObj.CheckSession(code);

                if (sessionState)
                {
                    IBookService bookService = new BookService();
                    IList<Book> books = bookService.GetAllBooks();

                    return View(books);
                }
                return View("Error");

            }
                
            catch (Exception e)
            {
                Console.WriteLine("Error retrieving books");
                Console.Write(e.ToString());
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult ViewBooksUser(String id)
        {
            try
            {
                int code = Convert.ToInt32(id);
                Boolean sessionState = sessionObj.CheckSession(code);

                if (sessionState)
                {
                    IBookService bookService = new BookService();
                    IList<Book> books = bookService.GetAllBooks();

                    return View(books);
                }
                return View("Error");
            }

            catch (Exception e)
            {
                Console.WriteLine("Error retrieving books");
                Console.Write(e.ToString());
                return View("Error");
            }
        }

        public ActionResult DeleteBooks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RequestBookPage(String id)
        {           
            int code = Convert.ToInt32(id);
            ViewBag.id = code;
            Boolean sessionState = sessionObj.CheckSession(code);

            if (sessionState)
            {
                Session session = sessionObj.GetSession(code);
                IBookService bookService = new BookService();
                IList<Book> books = bookService.GetAllBooks();
                return View(books);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult RequestBook(String bookId,String userId)
        {
            try
            {
                int userid = Convert.ToInt32(userId);
                int bookCode = Convert.ToInt32(bookId);
                Boolean sessionState = sessionObj.CheckSession(userid);

                if (sessionState)
                {                                               
                    IUserService userService = new UserService();
                    User user = userService.GetUserById(userid);
                    IBookService bookService = new BookService();
                    Book book = bookService.GetById(bookCode);
                    Boolean status = bookService.BookRequest(book, user);

                    if (status)
                    {
                        return Content("Success");
                    }
                    else
                    {
                        return Content("Failed");
                    }
                }

                return View("Error");
            }

            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.Write(e.ToString());
                return View("Error");
            }           
        }
    }
}
