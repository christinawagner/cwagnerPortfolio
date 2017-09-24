using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cwagnerPortfolio.Helpers;
using cwagnerPortfolio.Models;
using PagedList;
using PagedList.Mvc;

namespace cwagnerPortfolio.Controllers
{
    [RequireHttps]
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var posts = db.Posts.OrderByDescending(d => d.Created).AsQueryable();

            if (!User.IsInRole("Admin")) posts = posts.Where(p => p.Published);

            return View(posts.Include(i => i.Comments).ToPagedList(pageNumber, pageSize));
        }

        // POST: Search
        [HttpPost]
        public ActionResult Index(string searchStr, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ViewBag.Search = searchStr;
            SearchHelper search = new SearchHelper();
            var blogList = search.IndexSearch(searchStr);

            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return View(blogList.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(blogList.Where(p => p.Published == true).ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: Blog/Details/5
        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Posts.FirstOrDefault(p => p.Slug == Slug);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Title,Slug,Body,Created,Updated,MediaUrl,Published")] Blog blog, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format.");
            }
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    var filePath = "/wwwroot/images/";
                    var absPath = Server.MapPath("~" + filePath);
                    blog.MediaUrl = filePath + image.FileName;
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }
                var Slug = StringUtilities.URLFriendly(blog.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title");
                    return View(blog);
                }
                if (db.Posts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique");
                    return View(blog);
                }

                blog.Slug = Slug;
                blog.Created = DateTimeOffset.Now;
                db.Posts.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blog/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Blog blog = db.Posts.Find(id);
                if (blog == null)
                {
                    return HttpNotFound();
                }
                return View(blog);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Slug,Body,Created,Updated,MediaUrl,Published")] Blog blog, string mediaURL, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                {
                    ModelState.AddModelError("image", "Invalid Format.");
                }
            }
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filePath = "/wwwroot/images/";
                    var absPath = Server.MapPath("~" + filePath);
                    blog.MediaUrl = filePath + image.FileName;
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }
                else
                {
                    blog.MediaUrl = mediaURL;
                }
                blog.Updated = DateTimeOffset.Now;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blog/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Posts.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Posts.Find(id);
            db.Posts.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
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
