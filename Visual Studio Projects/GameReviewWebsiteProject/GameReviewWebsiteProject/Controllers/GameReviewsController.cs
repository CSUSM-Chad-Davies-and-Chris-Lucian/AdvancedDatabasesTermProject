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
    public class GameReviewsController : Controller
    {
        private GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        public ActionResult Index(String search = "")
        {
            ViewBag.PreviewSearch = search;
            var gamereviews = db.GameReviews.Where(x => x.Title.Contains(search)).Include(g => g.Author).Include(g => g.Game);

            return View(gamereviews.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            var gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            return View(gamereview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var db = new GameReviewWebsiteEntities();
                comment.GamerId = db.Gamers.First(x => User.Identity.Name == x.Name).GamerId;
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = comment.GameReviewId });
        }

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title");
            return View();
        }

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

        public ActionResult Edit(int id = 0)
        {
            var gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", gamereview.AuthorId);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", gamereview.GameId);
            return View(gamereview);
        }

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

        public ActionResult Delete(int id = 0)
        {
            GameReview gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            return View(gamereview);
        }

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