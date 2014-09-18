using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cs643_Project.Models;

namespace cs643_Project.Controllers
{
    public class GameReviewController : Controller
    {
        private GameReviewSiteEntities db = new GameReviewSiteEntities();

        //
        // GET: /GameReview/

        public ActionResult Index()
        {
            var gamereviews = db.GameReviews.Include(g => g.Author).Include(g => g.Game);
            return View(gamereviews.ToList());
        }

        //
        // GET: /GameReview/Details/5

        public ActionResult Details(int id = 0)
        {
            GameReview gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            return View(gamereview);
        }

        //
        // GET: /GameReview/Create

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title");
            return View();
        }

        //
        // POST: /GameReview/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameReview gamereview)
        {
            if (ModelState.IsValid)
            {
                db.GameReviews.Add(gamereview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", gamereview.AuthorId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", gamereview.GameId);
            return View(gamereview);
        }

        //
        // GET: /GameReview/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GameReview gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", gamereview.AuthorId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", gamereview.GameId);
            return View(gamereview);
        }

        //
        // POST: /GameReview/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameReview gamereview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamereview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", gamereview.AuthorId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", gamereview.GameId);
            return View(gamereview);
        }

        //
        // GET: /GameReview/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GameReview gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            return View(gamereview);
        }

        //
        // POST: /GameReview/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameReview gamereview = db.GameReviews.Find(id);
            db.GameReviews.Remove(gamereview);
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