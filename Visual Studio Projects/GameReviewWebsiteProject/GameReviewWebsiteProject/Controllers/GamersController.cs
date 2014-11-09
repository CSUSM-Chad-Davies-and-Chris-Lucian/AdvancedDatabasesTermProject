//Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/8/2014

using System;
using System.Linq;
using System.Web.Mvc;
using GameReviewWebsiteProject.Models;

namespace GameReviewWebsiteProject.Controllers
{
    //Controller for gamers
    public class GamersController : Controller
    {
        private readonly GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //Allows searching of gamers
        public ActionResult Index(String search = "")
        {
            ViewBag.SearchError = search.Length > 50 ? "Search is limited to 50 characters" : "";
            search = String.Join("", search.Take(50));
            ViewBag.PreviewSearch = search;
            //Generates the select statement for the search
            //See authors for an example
            var gamers = db.Gamers.Where(x => x.Name.Contains(search));

            return View(gamers.ToList());
        }

        //Shows details for a gamer based on the id passed in the URL
        public ActionResult Details(int id = 0)
        {
            //Generates select statement to get the gamer by id
            var gamer = db.Gamers.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        //Deconstructor
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}