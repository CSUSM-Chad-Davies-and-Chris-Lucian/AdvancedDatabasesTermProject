//Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/8/2014

using System;
using System.Linq;
using System.Web.Mvc;
using GameReviewWebsiteProject.Models;

namespace GameReviewWebsiteProject.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //Shows the Authors search page
        public ActionResult Index(String search = "")
        {
            ViewBag.SearchError = search.Length > 50 ? "Search is limited to 50 characters" : "";
            search = String.Join("", search.Take(50));
            ViewBag.PreviewSearch = search;

            //Select statement to the database
            //Automatically Generates code into query:

            var authors = db.Authors.Where(x => x.Name.Contains(search));
            //{SELECT 
            //[Extent1].[AuthorId] AS [AuthorId], 
            //[Extent1].[Name] AS [Name], 
            //[Extent1].[Genre] AS [Genre], 
            //[Extent1].[Biography] AS [Biography]
            //FROM [dbo].[Author] AS [Extent1]
            //WHERE [Extent1].[Name] LIKE @p__linq__0 ESCAPE N'~'}

            //Views route automatically to views of the same name
            return View(authors.ToList());
        }


        //Shows the details for a single author
        public ActionResult Details(int id = 0)
        {
            //Linq Query to select an author by id
            var author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //Destructor for the class
        protected override void Dispose(bool disposing)
        {
            //Dispose of the databse connection
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}