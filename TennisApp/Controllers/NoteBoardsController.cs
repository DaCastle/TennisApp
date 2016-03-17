using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TennisApp.Models;

namespace TennisApp.Controllers
{
    public class NoteBoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NoteBoards
        public ActionResult Index()
        {
            return View(db.NoteBoards.ToList());
        }

        // GET: NoteBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteBoard noteBoard = db.NoteBoards.Find(id);
            if (noteBoard == null)
            {
                return HttpNotFound();
            }
            return View(noteBoard);
        }

        // GET: NoteBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventId,note,userName,date")] NoteBoard noteBoard)
        {
            if (ModelState.IsValid)
            {
                noteBoard.userName = HttpContext.User.Identity.Name;
                noteBoard.date = DateTime.Now;
                db.NoteBoards.Add(noteBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noteBoard);
        }

        // GET: NoteBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteBoard noteBoard = db.NoteBoards.Find(id);
            if (noteBoard == null)
            {
                return HttpNotFound();
            }
            return View(noteBoard);
        }

        // POST: NoteBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventId,note,userName,date")] NoteBoard noteBoard)
        {
            if (ModelState.IsValid)
            {             
                noteBoard.userName = HttpContext.User.Identity.Name;
                noteBoard.date = DateTime.Now;
                db.Entry(noteBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noteBoard);
        }

        // GET: NoteBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteBoard noteBoard = db.NoteBoards.Find(id);
            if (noteBoard == null)
            {
                return HttpNotFound();
            }
            return View(noteBoard);
        }

        // POST: NoteBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoteBoard noteBoard = db.NoteBoards.Find(id);
            db.NoteBoards.Remove(noteBoard);
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
