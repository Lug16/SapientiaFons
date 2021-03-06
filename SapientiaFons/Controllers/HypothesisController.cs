﻿using Microsoft.AspNet.Identity;
using SapientiaFons.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SapientiaFons.Controllers
{
    public class HypothesisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hypothesis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hypothesis hypothesis = db.Hypotheses.Include(r => r.Subject).SingleOrDefault(r => r.Id == id);

            if (hypothesis == null)
            {
                return HttpNotFound();
            }

            if (hypothesis.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View(hypothesis);
        }

        // GET: Hypothesis/Create
        public ActionResult Create(int subjectId)
        {
            ViewBag.SubjectId = subjectId;
            return View();
        }

        // POST: Hypothesis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,Description,IsValid")] Hypothesis hypothesis)
        {
            if (ModelState.IsValid)
            {
                var subject = db.Subjects.Where(r => r.Id == hypothesis.SubjectId).Single();

                if (subject.UserId != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }

                db.Hypotheses.Add(hypothesis);
                db.SaveChanges();
                return RedirectToAction("Details", "Subject", new { id = hypothesis.SubjectId });
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UserId", hypothesis.SubjectId);
            return View(hypothesis);
        }

        // GET: Hypothesis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hypothesis hypothesis = db.Hypotheses.Include(r => r.Subject).SingleOrDefault(r => r.Id == id);

            if (hypothesis == null)
            {
                return HttpNotFound();
            }

            if (hypothesis.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "UserId", hypothesis.SubjectId);
            return View(hypothesis);
        }

        // POST: Hypothesis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsValid")] Hypothesis viewModel)
        {
            if (ModelState.IsValid)
            {
                Hypothesis hypothesis = db.Hypotheses.Include(r => r.Subject).SingleOrDefault(r => r.Id == viewModel.Id);

                if (hypothesis.Subject.UserId != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }

                hypothesis.Description = viewModel.Description;
                hypothesis.IsValid = viewModel.IsValid;

                db.Entry(hypothesis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Subject", new { id = hypothesis.SubjectId });
            }
            return View(viewModel);
        }

        // GET: Hypothesis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hypothesis hypothesis = db.Hypotheses.Include(r => r.Subject).SingleOrDefault(r => r.Id == id);

            if (hypothesis == null)
            {
                return HttpNotFound();
            }

            if (hypothesis.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View(hypothesis);
        }

        // POST: Hypothesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hypothesis hypothesis = db.Hypotheses.Include(r => r.Subject).SingleOrDefault(r => r.Id == id);

            if (hypothesis.Subject.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            db.Hypotheses.Remove(hypothesis);
            db.SaveChanges();
            return RedirectToAction("Details", "Subject", new { id = hypothesis.SubjectId });

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
