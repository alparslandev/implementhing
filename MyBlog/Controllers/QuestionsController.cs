using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyBlog.Models;
using PagedList;

namespace MyBlog.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Answer(string message, int id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            var questions = db.QuestionList.Find(id);
            if (questions.IsConfirmed)
            {
                var model = new Answers
                {
                    QuestionID = id,
                    Answer = message,
                    UserID = User.Identity.GetUserId()
                };
                db.AnswerList.Add(model);
                db.SaveChanges();
                return RedirectToAction("Questions");
            }
            return Content("<script language='javascript' " +
                           "type='text/javascript'>alert('This Question is not published yet. So you can not answer it.');" +
                           "history.go(-1); </script>");
        }

        [Authorize]
        public ActionResult Confirmed(int? id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                var questions = db.QuestionList.Find(id);
                questions.IsConfirmed = true;
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PendingApproval", db.QuestionList.Where(e => e.IsConfirmed).ToList());
            }

            return View("PendingApproval");
        }

        [Authorize]
        public ActionResult PendingApproval(string searchstring, int page = 1)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "PendingApproval";
            ViewBag.searchstring = searchstring;
            var list = from m in db.QuestionList where !m.IsConfirmed orderby m.Title select m;
            List<Questions> liste = new List<Questions>();
            if (searchstring != null && !String.IsNullOrEmpty(searchstring))
            {
                liste.AddRange(list.Where(e => e.Title.Contains(searchstring)));
                liste.AddRange(list.Where(e => e.Question.Contains(searchstring)));
                liste.AddRange(list.Where(e => e.Name.Contains(searchstring)));
            }
            else
            {
                liste.AddRange(list);
            }

            return View(liste.ToPagedList(page, 10));
        }

        [Authorize]
        public ActionResult Questions(string searchstring, int page = 1)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            ViewBag.searchstring = searchstring;
            var list = from m in db.QuestionList where m.IsConfirmed orderby m.Title select m;
            List<Questions> liste = new List<Questions>();
            if (searchstring != null && !String.IsNullOrEmpty(searchstring))
            {
                liste.AddRange(list.Where(e => e.Title.Contains(searchstring)));
                liste.AddRange(list.Where(e => e.Question.Contains(searchstring)));
                liste.AddRange(list.Where(e => e.Name.Contains(searchstring)));
            }
            else
            {
                liste.AddRange(list);
            }

            return View(liste.ToPagedList(page, 10));
        }

        [Authorize]
        public ActionResult Detay(int? id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions sorular = db.QuestionList.Find(id);
            if (sorular == null)
            {
                return HttpNotFound();
            }
            return View(sorular);
        }

        public ActionResult Index(string searchstring, int page = 1)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            ViewBag.searchstring = searchstring;
            var list = from m in db.QuestionList where m.IsConfirmed orderby m.Title select m;
            List<Questions> liste = new List<Questions>();
            if (searchstring != null && !String.IsNullOrEmpty(searchstring))
            {
                liste.AddRange(list.Where(e => e.Title.Contains(searchstring)));
                liste.AddRange(list.Where(e => e.Question.Contains(searchstring)));
                liste.AddRange(list.Where(e => e.Name.Contains(searchstring)));
            }
            else
            {
                liste.AddRange(list);
            }

            return View(liste.ToPagedList(page, 10));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.QuestionList.Find(id);
            var answers = db.AnswerList.FirstOrDefault(e => e.QuestionID == id.Value);
            if (answers != null)
            {
                ViewBag.cevap = answers.Answer;
                ViewBag.user = Name.getName(answers.UserID);
                ViewBag.date = answers.Date;
            }

            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Question,Name,Surname,EMail,IsConfirmed,Date")] Questions questions)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (ModelState.IsValid)
            {
                db.QuestionList.Add(questions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questions);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.QuestionList.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Question,Name,Surname,EMail,IsConfirmed,Date")] Questions questions)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (ModelState.IsValid)
            {
                db.Entry(questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questions);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questions questions = db.QuestionList.Find(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(questions);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Title = Name.IsEnglish() ? "Sorular" : "Questions";
            ViewBag.active = "Questions";
            Questions questions = db.QuestionList.Find(id);
            db.QuestionList.Remove(questions);
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
