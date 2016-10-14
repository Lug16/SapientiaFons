using SapientiaFons.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SapientiaFons.Controllers
{
    public class SubjectModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectModels
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.User);
            return View(subjects.ToList());
        }

        // GET: SubjectModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectModel subjectModel = db.Subjects.Find(id);
            if (subjectModel == null)
            {
                return HttpNotFound();
            }
            return View(subjectModel);
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
        public ActionResult Create([Bind(Include = "Id,UserId,Title,Description,Date,ShortUrl")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subjectModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", subjectModel.UserId);
            return View(subjectModel);
        }

        // GET: SubjectModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectModel subjectModel = db.Subjects.Find(id);
            if (subjectModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", subjectModel.UserId);
            return View(subjectModel);
        }

        // POST: SubjectModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Title,Description,Date,ShortUrl")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", subjectModel.UserId);
            return View(subjectModel);
        }

        // GET: SubjectModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectModel subjectModel = db.Subjects.Find(id);
            if (subjectModel == null)
            {
                return HttpNotFound();
            }
            return View(subjectModel);
        }

        // POST: SubjectModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectModel subjectModel = db.Subjects.Find(id);
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
