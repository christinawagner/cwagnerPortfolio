using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using cwagnerPortfolio.Models;

namespace cwagnerPortfolio.Helpers
{
    public class ForcePasswordResetFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName == "ChangePassword")
            {
                return;
            }

            var identity = filterContext.HttpContext.User.Identity;
            if (identity.IsAuthenticated)
            {
                using (var db = new ApplicationDbContext())
                {
                    var user = db.Users.Single(u => u.UserName == identity.Name);
                    if (user.ForcePasswordReset)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Manage", action = "ChangePassword" }));
                    }
                }
            }
        }
    }
}