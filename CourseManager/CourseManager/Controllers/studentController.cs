using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class studentController : Controller
    {
        private courseManagerEntities db = new courseManagerEntities();

        //
        // GET: /student/

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /student/Details/5

        public ActionResult Details(int id = 0)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // GET: /student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /student/Create

        [HttpPost]
        public ActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        //
        // GET: /student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // POST: /student/Edit/5

        [HttpPost]
        public ActionResult Edit(Students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        //
        // GET: /student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // POST: /student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}