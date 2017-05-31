using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyBlog.Models;
using MyBlog.Models.ViewModels;
using PagedList;

namespace MyBlog.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blogsvar userId = User.Identity.GetUserId();
        //var userName = db.Users.Where(e => e.Id == userId).Select(e => e.Email).FirstOrDefault();
        public ActionResult Index(int page = 1)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            List<BlogsVM> list = new List<BlogsVM>();

            foreach (var item in db.ArticlesSet.ToList())
            {
                if (item.IsPublished)
                {
                    string title = item.Title, content = item.Content, summary = item.Summary;
                    if (Name.IsEnglish())
                    {
                        summary = item.SummaryEnglish;
                        title = item.TitleEnglish;
                        content = item.ContentEnglish;
                    }

                    var model = new BlogsVM
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Name = Name.getName(User.Identity.GetUserId()),
                        Title = title,
                        Summary = summary,
                        IsPublished = item.IsPublished,
                        Content = content
                    };
                    list.Add(model);
                }
            }

            ViewBag.page = page;
            return View(list.OrderBy(e => e.Title).ToPagedList(page, 10));
        }

        [Authorize]
        public ActionResult Detay(int? id)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blog = db.ArticlesSet.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            var model = new BlogsVM
            {
                Title = blog.Title,
                Content = blog.Content,
                Date = blog.Date,
                Id = blog.Id,
                Summary = blog.Summary,
                IsPublished = blog.IsPublished,
                Name = Name.getName(User.Identity.GetUserId())
            };

            if (Name.IsEnglish())
            {
                model.Summary = blog.SummaryEnglish;
                model.Title = blog.TitleEnglish;
                model.Content = blog.ContentEnglish;
            }

            ViewBag.name = Name.getName(blog.UserId);
            return View(model);
        }

        [Authorize]
        public ActionResult Publish(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blog = db.ArticlesSet.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                blog.IsPublished = !blog.IsPublished;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Bloglist");
        }

        [Authorize]
        public ActionResult Bloglist(int page = 1)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            List<BlogsVM> list = new List<BlogsVM>();

            foreach (var item in db.ArticlesSet.ToList())
            {
                string title = item.Title, content = item.Content, summary = item.Summary;
                if (Name.IsEnglish())
                {
                    summary = item.SummaryEnglish;
                    title = item.TitleEnglish;
                    content = item.ContentEnglish;
                }

                var model = new BlogsVM
                {
                    Id = item.Id,
                    Date = item.Date,
                    Summary = summary,
                    IsPublished = item.IsPublished,
                    Name = "Alparslan Selçuk DEVELİOĞLU",
                    Title = title,
                    Content = content
                };

                if (Name.IsEnglish())
                {
                    model.Summary = item.SummaryEnglish;
                    model.Title = item.TitleEnglish;
                    model.Content = item.ContentEnglish;
                }

                list.Add(model);
            }

            ViewBag.page = page;
            return View(list.OrderBy(e => e.Title).ToPagedList(page, 10));
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blog = db.ArticlesSet.Find(id);
            if (blog == null || !blog.IsPublished)
            {
                return HttpNotFound();
            }

            var model = new BlogsVM
            {
                Title = blog.Title,
                Content = blog.Content,
                Date = blog.Date,
                Id = blog.Id,
                Summary = blog.Summary,
                Name = Name.getName(User.Identity.GetUserId())
            };

            if (Name.IsEnglish())
            {
                model.Summary = blog.SummaryEnglish;
                model.Title = blog.TitleEnglish;
                model.Content = blog.ContentEnglish;
            }

            ViewBag.name = Name.getName(blog.UserId);
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blogs blog)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            if (ModelState.IsValid)
            {
                var model = new Blogs
                {
                    Title = blog.Title,
                    Content = blog.Content,
                    IsPublished = blog.IsPublished,
                    ContentEnglish = blog.ContentEnglish,
                    TitleEnglish = blog.TitleEnglish,
                    Summary = blog.Summary,
                    SummaryEnglish = blog.SummaryEnglish,
                    UserId = User.Identity.GetUserId()
                };
                db.ArticlesSet.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blogs = db.ArticlesSet.Find(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            return View(blogs);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blogs blogs)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            if (ModelState.IsValid)
            {
                db.Entry(blogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogs);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blog = db.ArticlesSet.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            var model = new BlogsVM
            {
                Title = blog.Title,
                Content = blog.Content,
                Date = blog.Date,
                Id = blog.Id,
                Name = Name.getName(User.Identity.GetUserId())
            };

            if (Name.IsEnglish())
            {
                model.Title = blog.TitleEnglish;
                model.Content = blog.ContentEnglish;
            }

            ViewBag.name = Name.getName(blog.UserId);
            return View(model);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Title = "Blog";
            ViewBag.active = "Blog";
            Blogs blogs = db.ArticlesSet.Find(id);
            db.ArticlesSet.Remove(blogs);
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
