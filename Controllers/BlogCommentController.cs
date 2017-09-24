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
        //deleted

        // GET: BlogComment/Details/5
        //deleted

        // GET: BlogComment/Create
        //deleted

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
        //deleted

        // POST: BlogComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,BlogId,Body,Created,Updated,UpdatedReason")] BlogComment updatedComment, int blogId)
        {
            var blogComment = db.BlogComments.Find(updatedComment.Id);

            if (ModelState.IsValid && (User.IsInRole("Admin") || User.IsInRole("Moderator") || blogComment.AuthorId == User.Identity.GetUserId()))
            {
                blogComment.Updated = DateTimeOffset.Now;
                blogComment.Body = updatedComment.Body;
                
                db.Entry(blogComment).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Details", "Blog", new { slug = blogComment.Blog.Slug });
        }

        // POST: BlogComment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var blogComment = db.BlogComments.Find(id);

            if(User.IsInRole("Admin") || User.IsInRole("Moderator") || blogComment.AuthorId == User.Identity.GetUserId())
            {
            db.BlogComments.Remove(blogComment);
            db.SaveChanges();
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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
