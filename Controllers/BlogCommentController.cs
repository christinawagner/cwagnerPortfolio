using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cwagnerPortfolio.Models;
using Microsoft.AspNet.Identity;

namespace cwagnerPortfolio.Controllers
{
    public class BlogCommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogComment
        //public ActionResult Index()
        //{
        //    var blogComments = db.BlogComments.Include(b => b.Author).Include(b => b.Blog);
        //    return View(blogComments.ToList());
        //}

        // GET: BlogComment/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogComment blogComment = db.BlogComments.Find(id);
        //    if (blogComment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogComment);
        //}

        // GET: BlogComment/Create
        //public ActionResult Create()
        //{
        //    ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
        //    ViewBag.BlogId = new SelectList(db.Posts, "Id", "Title");
        //    return View();
        //}

        // POST: BlogComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,AuthorId,BlogId,Body,Created,Updated,UpdatedReason")] BlogComment blogComment, int blogId)
        {
            var blog = db.Posts.Find(blogId);

            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());

                blogComment.BlogId = blogId;
                blogComment.AuthorId = user.Id;
                blogComment.Created = DateTimeOffset.Now;
                db.BlogComments.Add(blogComment);
                db.SaveChanges();
            }

            return RedirectToAction("Details", "Blog", new { slug = blog.Slug });
        }

        // GET: BlogComment/Edit/5
        [Authorize(Roles = "Admin Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }

            return View("Details", "Blog", id);
        }

        // POST: BlogComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin Moderator")]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,BlogId,Body,Created,Updated,UpdatedReason")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Details", "Blog");
        }

        // GET: BlogComment/Delete/5
        [Authorize(Roles = "Admin Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = db.BlogComments.Find(id);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View("Details", "Blog");
        }

        // POST: BlogComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin Moderator")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogComment blogComment = db.BlogComments.Find(id);
            db.BlogComments.Remove(blogComment);
            db.SaveChanges();
            return RedirectToAction("Details", "Blog");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
