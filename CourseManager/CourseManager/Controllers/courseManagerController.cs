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
    public class courseManagerController : Controller
    {
        private courseManagerEntities db = new courseManagerEntities();

        //
        // GET: /courseManager/

        public ActionResult Index()
        {
            return View(db.CourseManagements.ToList());
        }

        //
        // GET: /courseManager/Details/5

        public ActionResult Details(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // GET: /courseManager/Create

        public ActionResult Create()
        {
            var classes = db.Classes.ToList();
            ViewBag.Classes = classes;

            var teachers = db.Teacher.ToList();
            ViewBag.Teachers = teachers;

            var course= db.Course.ToList();
            ViewBag.Courses = course;

            return View();
        }

        //
        // POST: /courseManager/Create

        [HttpPost]
        public ActionResult Create(CourseManagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.CourseManagements.Add(coursemanagements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemanagements);
        }

        //
        // GET: /courseManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /courseManager/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseManagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemanagements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemanagements);
        }

        //
        // GET: /courseManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /courseManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            db.CourseManagements.Remove(coursemanagements);
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