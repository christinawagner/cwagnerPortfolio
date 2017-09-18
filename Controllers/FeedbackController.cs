using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using cwagnerPortfolio.Models;

namespace cwagnerPortfolio.Controllers
{
    [RequireHttps]
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>" +
                        "({1})</p><p>Subject: </p><p>{2}</p><p>Message: </p><p>{3}</p><p>{4}</p>";
                    var from = "MyPortfolio<cwagner0604@gmail.com>";
                    var footNote = "This is a message from your portfolio site.  The name and the email of the contacting person is above.";
                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Subject, model.Body, footNote),
                        IsBodyHtml = true
                    };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);
                    return RedirectToAction("Sent");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }

        //Message Sent
        public ActionResult Sent()
        {
            return View();
        }
    }
}