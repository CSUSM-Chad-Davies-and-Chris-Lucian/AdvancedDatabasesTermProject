//Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/8/2014

using System.Web.Mvc;
using GameReviewWebsiteProject.Models;

namespace GameReviewWebsiteProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly GameReviewWebsiteEntities db = new GameReviewWebsiteEntities();

        //Shows the review for deleting a comment
        public ActionResult Delete(int id = 0, string orgin = "GameReviews")
        {
            //Generates the SQL to select the comments by id
            var comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.orgin = orgin;
            return View(comment);
        }

        //Post action to delete the comment referenced by id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string orgin = "GameReviews")
        {
            //Get the comment by ID
            var comment = db.Comments.Find(id);
            //Queues the removal of the comment
            db.Comments.Remove(comment);
            //Generates and commits the delete statement
            db.SaveChanges();

            //Redirects to the appropriate location
            return RedirectToCommentOrigin(orgin, comment);
        }

        //Redirect to the selected origin
        public ActionResult RedirectToCommentOrigin(int id, string orgin = "GameReviews")
        {
            var comment = db.Comments.Find(id);
            return RedirectToCommentOrigin(orgin, comment);
        }

        //overload for more detail
        private ActionResult RedirectToCommentOrigin(string orgin, Comment comment)
        {
            return RedirectToAction("Details", orgin, new {id = orgin == "GameReviews" ? comment.GameReviewId : comment.GamerId});
        }

        //Deconstructor
        protected override void Dispose(bool disposing)
        {
            //Disconnect from the database
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}