using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cwagnerPortfolio.Models;

namespace cwagnerPortfolio.Controllers
{
    [RequireHttps]
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JS()
        {
            return View();
        }

        public ActionResult ShoppingApp()
        {
            return View();
        }

        public ActionResult BugTracker()
        {
            return View();
        }

        public ActionResult FinancialPortal()
        {
            return View();
        }

        public PartialViewResult LoadJavascriptModal(JsExerciseViewModel model)
        {
            return PartialView("_JavascriptExerciseModal", model);
        }
    }
}