using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameReviewWebsiteProject.Models;

namespace GameReviewWebsiteProject.Controllers
{
    public class GamersController : Controller
    {
        private GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //
        // GET: /Gamers/

        public ActionResult Index()
        {
            return View(db.Gamers.ToList());
        }

        //
        // GET: /Gamers/Details/5

        public ActionResult Details(int id = 0)
        {
            Gamer gamer = db.Gamers.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        //
        // GET: /Gamers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gamers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Gamers.Add(gamer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gamer);
        }

        //
        // GET: /Gamers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gamer gamer = db.Gamers.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        //
        // POST: /Gamers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gamer gamer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gamer);
        }

        //
        // GET: /Gamers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gamer gamer = db.Gamers.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        //
        // POST: /Gamers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gamer gamer = db.Gamers.Find(id);
            db.Gamers.Remove(gamer);
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