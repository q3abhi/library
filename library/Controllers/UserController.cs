using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using library.Filters;
using ModelLibrary;
using ServiceLibrary;

namespace library.Controllers
{
    public class UserController : Controller
    {
        SessionObjects sessionObj = SessionObjects.CreateInstance();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            try
            {
                IUserService service = new UserService();

                Boolean status = service.Create(user); // Fire the query

                if (status)
                {
                    return Content("Success");
                }
                    return Content("Error");
            }

            catch (Exception e)
            {
                Console.Write("Error creating user");
                return Content("Error");
            }

        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Success()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(String username , String password)
        { 
            IUserService service = new UserService();

            UserDto retUserDto = service.ValidateUser(username,password);
     
            String json = new JavaScriptSerializer().Serialize(retUserDto);

            if (retUserDto == null)
            {
                return Content("null");
            }
            else
            {
                try
                {                 
                    Session session = sessionObj.CreateSession(retUserDto);

                    if (session != null)
                        return Content(retUserDto.Id.ToString());
                    else
                        return Content("error");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Session could not be created");
                    return Content("existing");
                }
            }                
        }
        
        
        public ActionResult Loginpage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout(String id)
        {
            int code = Convert.ToInt32(id);

            Boolean sessionState = sessionObj.CheckSession(code);

            if (sessionState)
            {
                Boolean deleteStatus = sessionObj.DeleteSession(code);

                return Content(deleteStatus ? "Success" : "Failed");
            }

            return Content("Failed");
        }

        [HttpGet]
        [SessionChecker]
        public ActionResult SearchUserPage(String userId)
        {
            try
            {
                ViewBag.userId = userId;
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine("SearchUserPage Error");
                Console.Write(e.ToString());
                return View("Error");
            }
  
        }

        [HttpPost]
        [SessionChecker]
        public ActionResult SearchUser(String userId, String searchString)
        {
            try
            {
                ViewBag.userId = userId;
                IUserService userService = new UserService();
                IList<UserBookRequest> userList = userService.UserSearch(searchString);
                return View(userList);
            }
            catch (Exception e)
            {
                Console.WriteLine("SearchUser Error");
                Console.Write(e.ToString());
                return Content("Error");
            }
        }

    }
}
