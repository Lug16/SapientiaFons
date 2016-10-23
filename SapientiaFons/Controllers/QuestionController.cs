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
            Question question = db.Questions.Include(s => s.Hypothesis).Where(r => r.Id == id).Single();
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create(int subjectId, int? hypothesisId)
        {
            ViewBag.Hypotheses = db.Hypotheses.OrderBy(r => r.Description).Select(r => new SelectListItem { Text = r.Description, Value = r.Id.ToString() }).ToArray();
            ViewBag.SubjectId = subjectId;
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,SubjectId,HypothesisId")] Question question)
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
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.HypothesisId = new SelectList(db.Hypotheses.OrderBy(r => r.Description), "Id", "Description", question.HypothesisId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UserId", question.SubjectId);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,SubjectId,HypothesisId")] Question question)
        {
            if (ModelState.IsValid)
            {
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
            Question question = db.Questions.Include(s => s.Hypothesis).Where(r => r.Id == id).Single();
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
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
