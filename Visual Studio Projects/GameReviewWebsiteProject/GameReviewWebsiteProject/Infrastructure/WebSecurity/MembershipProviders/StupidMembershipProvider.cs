//Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/8/2014

using System.Linq;
using GameReviewWebsiteProject.Models;
using WebMatrix.WebData;

namespace GameReviewWebsiteProject.Infrastructure.WebSecurity.MembershipProviders
{
    //This class overrides the built in authentication system of .net 
    //Typically we would have used the automatically generated tables from .net but 
    //since this is a project we went for ultra simple.
    public class StupidMembershipProvider : SimpleMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            var db = new GameReviewWebsiteEntities();
            //Generates the query for logging in, then converts it to a list, then runs the 
            //Linq Any function on the list which is equivelent of the boolean experssion (list.Count() > 0):
            var userIsValid = db.Gamers.Where(x => x.Name == username).ToList().Any(x => x.Password == password);
            return userIsValid;
        }
    }
}