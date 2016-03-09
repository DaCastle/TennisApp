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
    public class MatchResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MatchResults
        public ActionResult Index()
        {
            return View(db.MatchResults.ToList());
        }

        // GET: MatchResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchResults matchResults = db.MatchResults.Find(id);
            if (matchResults == null)
            {
                return HttpNotFound();
            }
            return View(matchResults);
        }

        // GET: MatchResults/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "MatchId,player1,player2,date,gameScore")] MatchResults matchResults)
        {
            if (ModelState.IsValid)
            {
                db.MatchResults.Add(matchResults);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matchResults);
        }

        // GET: MatchResults/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchResults matchResults = db.MatchResults.Find(id);
            if (matchResults == null)
            {
                return HttpNotFound();
            }
            return View(matchResults);
        }

        // POST: MatchResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "MatchId,player1,player2,date,gameScore")] MatchResults matchResults)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchResults).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matchResults);
        }

        // GET: MatchResults/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchResults matchResults = db.MatchResults.Find(id);
            if (matchResults == null)
            {
                return HttpNotFound();
            }
            return View(matchResults);
        }

        // POST: MatchResults/Delete/5
        [Authorize(Roles = "canEdit")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchResults matchResults = db.MatchResults.Find(id);
            db.MatchResults.Remove(matchResults);
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
