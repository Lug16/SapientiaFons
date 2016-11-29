using Microsoft.AspNet.Identity;
using SapientiaFons.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SapientiaFons.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Include(s => s.Hypothesis).Include(r => r.Subject).Where(r => r.Id == id).Single();
            if (question == null)
            {
                return HttpNotFound();
            }

            if (question.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create(int subjectId, int? hypothesisId)
        {
            var subject = db.Subjects.Where(r => r.Id == subjectId).Single();

            if (subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            ViewBag.Hypotheses = db.Hypotheses
                                        .Where(r => r.SubjectId == subjectId)
                                        .OrderBy(r => r.Description)
                                        .Select(r =>
                                            new SelectListItem
                                            {
                                                Text = r.Description,
                                                Value = r.Id.ToString()
                                            }).ToArray();
            ViewBag.SubjectId = subjectId;
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,SubjectId,HypothesisId,IsValid")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Details", "Subject", new { id = question.SubjectId });
            }

            ViewBag.HypothesisId = new SelectList(db.Hypotheses.OrderBy(r => r.Description), "Id", "Description", question.HypothesisId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UserId", question.SubjectId);
            return RedirectToAction("Details", "Subject", new { id = question.SubjectId });
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Include(r => r.Subject).Single(r => r.Id == id);
            if (question == null)
            {
                return HttpNotFound();
            }

            if (question.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            ViewBag.HypothesisId = new SelectList(db.Hypotheses
                                                        .Where(r => r.SubjectId == question.SubjectId)
                                                        .OrderBy(r => r.Description), "Id", "Description", question.HypothesisId);

            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UserId", question.SubjectId);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,SubjectId,HypothesisId,IsValid")] Question question)
        {
            if (ModelState.IsValid)
            {
                var subject = db.Subjects.Where(r => r.Id == question.SubjectId).Single();

                if (subject.UserId != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }

                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Subject", new { id = question.SubjectId });

            }

            return RedirectToAction("Details", "Subject", new { id = question.SubjectId });
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Include(s => s.Hypothesis).Include(r => r.Subject).Where(r => r.Id == id).Single();
            if (question == null)
            {
                return HttpNotFound();
            }

            if (question.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Include(r => r.Subject).Where(r => r.Id == id).Single();

            if (question.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Details", "Subject", new { id = question.SubjectId });
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
