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
    public class AuthorsController : Controller
    {
        private GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //
        // GET: /Authors/

        public ActionResult Index(String search = "")
        {
            ViewBag.PreviewSearch = search;
            var authors = db.Authors.Where(x => x.Name.Contains(search));//.Include(g => g.GameReviews);

            return View(authors.ToList());
        }

        //
        // GET: /Authors/Details/5

        public ActionResult Details(int id = 0)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //
        // GET: /Authors/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Authors/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        //
        // GET: /Authors/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //
        // POST: /Authors/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        //
        // GET: /Authors/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //
        // POST: /Authors/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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