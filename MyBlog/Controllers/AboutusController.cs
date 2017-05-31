using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MyBlog.Models;
using MyBlog.Models.ViewModels;

namespace MyBlog.Controllers
{
    public class AboutusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = Name.IsEnglish() ? "Hakkımda" : "About Me";
            ViewBag.active = "Aboutus";
            Aboutus aboutus = db.AboutusArticle.Find(1);
            if (aboutus == null)
            {
                return HttpNotFound();
            }
            var model = new AboutusVM
            {
                Id = aboutus.Id,
                Content = aboutus.Content,
                Title = aboutus.Title
            };

            if (Name.IsEnglish())
            {
                model.Content = aboutus.EnglishContent;
                model.Title = aboutus.TitleEnglish;
            }
            List<AboutusVM> list = new List<AboutusVM>();
            list.Add(model);
            return View(list);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.active = "Aboutus";
            ViewBag.Title = Name.IsEnglish() ? "Hakkımda" : "About Me";
            Aboutus aboutus = db.AboutusArticle.Find(1);
            if (aboutus == null)
            {
                return View();
            }

            return View(aboutus);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aboutus aboutus)
        {
            ViewBag.active = "Aboutus";
            if (ModelState.IsValid)
            {
                if (db.AboutusArticle.Find(1) != null)
                {
                    aboutus.Id = 1;
                    var local = db.Set<Aboutus>().Local.FirstOrDefault(e => e.Id == 1);
                    if (local != null)
                    {
                        db.Entry(local).State = EntityState.Detached;
                    }
                    db.Entry(aboutus).State = EntityState.Modified;
                }
                    
                else
                    db.AboutusArticle.Add(aboutus);
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutus);
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
