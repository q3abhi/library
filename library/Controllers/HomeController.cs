using System;
using System.Web.Mvc;
using ModelLibrary;

namespace library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("LoginPage", "User");
        }

        [HttpPost]
        public ActionResult Index(String id)
        {
            try
            {
                int code = Convert.ToInt32(id);
                SessionObjects sessionobj = SessionObjects.CreateInstance();
                Session session = sessionobj.GetSession(code);
                
                if (session!=null) 
                return View(session);   
       
                return RedirectToAction("Error");
            }

            catch (Exception e)
            {
                Console.Write("There was some problem with the home controller");
                return RedirectToAction("Error");
            }            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
