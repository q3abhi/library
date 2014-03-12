using System;
using System.Web;
using System.Web.Mvc;

namespace library.Controllers
{
    public class HelloController : Controller
    {
 
        public ActionResult Index()
        {
            SessionObjects sessionobj = SessionObjects.CreateInstance();
       //     sessionobj.GetSession()
            return View();
        }

        // 
        // GET: /Hello/Welcome/ 

        public string Welcome(String name, int age)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", Age is: " + age);
        } 

    }
}
