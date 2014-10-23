using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using GameReviewWebsiteProject.Models;
using WebMatrix.WebData;

namespace GameReviewWebsiteProject.Infrastructure.WebSecurity.MembershipProviders
{
    public class StupidMembershipProvider : SimpleMembershipProvider
    {
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return base.GetUser(username, userIsOnline);
        }

        public override bool ValidateUser(string username, string password)
        {
            var db = new GameReviewWebsiteEntities();
            return db.Gamers.Where(x => x.Name == username)
                .ToList()
                .Any(x => x.Password == password);
        }
    }
}