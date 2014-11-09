//Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/8/2014

using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GameReviewWebsiteProject.Models;

namespace GameReviewWebsiteProject.Controllers
{
    //Class for managing the actions relating to Game Reviews
    public class GameReviewsController : Controller
    {
        private readonly GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //Search index for Game Reviews
        //Also the first page the users see when they connect to the site for the first time
        public ActionResult Index(String search = "")
        {
            ViewBag.SearchError = search.Length > 50 ? "Search is limited to 50 characters" : "";
            search = String.Join("", search.Take(50));
            ViewBag.PreviewSearch = search;

            //Generates the search sql
            //See Authors Action for example
            var gamereviews = db.GameReviews.Where(x => x.Title.Contains(search)).Include(g => g.Author).Include(g => g.Game);

            return View(gamereviews.ToList());
        }

        //Shows the details of a single GameReview by ID
        public ActionResult Details(int id = 0)
        {
            var gamereview = db.GameReviews.Find(id);
            if (gamereview == null)
            {
                return HttpNotFound();
            }
            return View(gamereview);
        }

        //The post action to create a comment from a game review
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                //Select the gamer based on logged in usr name
                comment.GamerId = db.Gamers.First(x => User.Identity.Name == x.Name).GamerId;
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = comment.GameReviewId });
        }

        //Deconstructor
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}