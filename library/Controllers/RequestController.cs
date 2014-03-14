using System;
using System.Collections.Generic;
using System.Web.Mvc;
using library.Filters;
using ModelLibrary;
using ServiceLibrary;

namespace library.Controllers
{
    [SessionChecker]
    public class RequestController : Controller
    {

        [HttpGet]
        public ActionResult ViewBookRequest(String userId)
        {
            try
            {
                int userid = Convert.ToInt32(userId);
                IUserBookRequestService userBookRequestService = new UserBookRequestService();
                IList<UserBookRequest> userBookRequestList = userBookRequestService.ReadAllActiveRequestsForUser(userid);
                return View(userBookRequestList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error at ViewBookRequest");
                Console.Write(e.ToString());
                return Content("Failed");
            }
        }


        [HttpPost]
        public ActionResult Add(String bookId, String userId)
        {
            try
            {
                int userid = Convert.ToInt32(userId);
                int bookid = Convert.ToInt32(bookId);
                IBookRequestService bookRequestService = new BookRequestService();
                IUserBookRequestService userBookRequestService = new UserBookRequestService();
                Boolean bookRequestStatus = bookRequestService.Add(bookid);
                Boolean userBookRequestStatus = userBookRequestService.Add(userid, bookid);

                if ((bookRequestStatus && userBookRequestStatus).Equals(true))
                {
                    return Content("Success");
                }

                return Content("Failed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestController , Add()");
                Console.Write(e.ToString());
                return Content("Failed");
            }
            
        }

        [HttpGet]
        public ActionResult ApproveBookRequestsPage(String userId)
        {
            try
            {  
                IBookRequestService bookRequestService = new BookRequestService();
                IList<UserBookRequest> userBookRequests = bookRequestService.FetchAllPendingRequests();
                ViewBag.id = userId;
                return View(userBookRequests);            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestController , ApproveBookRequestsPage()");
                Console.Write(e.ToString());
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult ApproveRequest(String requestId,String userId)
        {
            try
            {
                int requestid = Convert.ToInt32(requestId);

                IUserBookRequestService userBookRequestService = new UserBookRequestService();
                Boolean approvalStatus = userBookRequestService.ApproveBookRequestForUser(requestid);

                if ((approvalStatus).Equals(true))
                {
                    return Content("Success");
                }
                return Content("Failed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestController , Add()");
                Console.Write(e.ToString());
                return Content("Failed");
            }
 
        }

        public ActionResult ViewReturnsPage(String userId)
        {
            try
            {  
                 //IBookRequestService bookRequestService;
                 //IList<UserBookRequest> userBookRequests = bookRequestService.FetchPendingRequests();
                 //return View();
              return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestController , ViewReturnsPage()");
                Console.Write(e.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult BookReturn(String userId, String returnId)
        {
            try
            {
                int returnid = Convert.ToInt32(returnId);

                IUserBookRequestService userBookRequestService = new UserBookRequestService();
                var status = userBookRequestService.DeleteBookRequestForUser(returnid);
                if (status)
                {
                    return Content("Success");
                }
                return Content("Failed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequestController , BookRet");
                Console.Write(e.ToString());
                return Content("Failed");
            }
        }
    }
}
