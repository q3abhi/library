using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

    }
}
