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
    //Controller to manage games actions
    public class GamesController : Controller
    {
        private readonly GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //Search action for games
        public ActionResult Index(String search = "")
        {
            ViewBag.SearchError = search.Length > 50 ? "Search is limited to 50 characters" : "";
            search = String.Join("", search.Take(50));
            ViewBag.PreviewSearch = search;
            var games = db.Games.Where(x => x.Title.Contains(search)).Include(g => g.GameReviews);

            return View(games.ToList());
        }

        //Shows the details of a game by its id
        public ActionResult Details(int id = 0)
        {
            //Generates the Sql statement to query the game
            var game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        //Deconstructor
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}