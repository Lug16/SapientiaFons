using Microsoft.AspNet.Identity;
using SapientiaFons.Models;
using SapientiaFons.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SapientiaFons.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectModels
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var subjects = db.Subjects.Include(s => s.User).Where(r => r.UserId == userId);
            return View(subjects.Select(r => new SubjectViewModel { Date = r.Date, Description = r.Description, Id = r.Id, ShortUrl = r.ShortUrl, Title = r.Title }));
        }

        // GET: SubjectModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subjectModel = db.Subjects.Find(id);
            if (subjectModel == null)
            {
                return HttpNotFound();
            }

            if (User.Identity.GetUserId() != subjectModel.UserId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            ViewBag.SubjectId = id;
            ViewBag.Materials = db.Materials.Where(r => r.SubjectId == id).OrderBy(r => r.Description).ToArray();
            ViewBag.Activities = db.Activities.Where(r => r.SubjectId == id).OrderBy(r => r.Name).ToArray();
            ViewBag.Hypotheses = db.Hypotheses.Where(r => r.SubjectId == id).OrderBy(r => r.Description).ToArray();
            ViewBag.Questions = db.Questions.Where(r => r.SubjectId == id).OrderBy(r => r.Description).ToArray();

            return View(new SubjectViewModel { Id = id.Value, Description = subjectModel.Description, Title = subjectModel.Title, Date = subjectModel.Date, ShortUrl = subjectModel.ShortUrl });
        }

        // GET: SubjectModels/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: SubjectModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description")] SubjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject
                {
                    Date = DateTime.Now,
                    ShortUrl = db.GetShortUrl(),
                    Title = viewModel.Title,
                    UserId = User.Identity.GetUserId(),
                    Description = viewModel.Description
                };

                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", subjectModel.UserId);
            return View(viewModel);
        }

        // GET: SubjectModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subjectModel = db.Subjects.Find(id);
            if (subjectModel == null)
            {
                return HttpNotFound();
            }

            if (User.Identity.GetUserId() != subjectModel.UserId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", subjectModel.UserId);
            return View(new SubjectViewModel { Id = id.Value, Description = subjectModel.Description, Title = subjectModel.Title });
        }

        // POST: SubjectModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description")] SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subject = db.Subjects.Where(r => r.Id == model.Id).Single();

                if (User.Identity.GetUserId() != subject.UserId)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }

                subject.Title = model.Title;
                subject.Description = model.Description;

                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", subjectModel.UserId);
            return View(model);
        }

        // GET: SubjectModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subjectModel = db.Subjects.Find(id);
            if (subjectModel == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.GetUserId() != subjectModel.UserId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View(new SubjectViewModel { Id = id.Value, Description = subjectModel.Description, Title = subjectModel.Title, Date = subjectModel.Date, ShortUrl = subjectModel.ShortUrl });
        }

        // POST: SubjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subjectModel = db.Subjects.Find(id);

            if (User.Identity.GetUserId() != subjectModel.UserId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            db.Subjects.Remove(subjectModel);
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
