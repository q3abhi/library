using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace library.Filters
{
    public class SessionCheckerAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionObjects sessionObj = SessionObjects.CreateInstance();
            String id = (String)filterContext.ActionParameters["userId"];
            int code = Int32.Parse(id);
            Boolean sessionState = sessionObj.CheckSession(code);

            if (!sessionState)
            {
                var route = new RouteValueDictionary {{"controller", "User"}, {"action", "Error"}};
                filterContext.Result = new RedirectToRouteResult(route);
            }
        }
    }
}