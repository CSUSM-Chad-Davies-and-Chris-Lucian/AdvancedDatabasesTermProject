//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameReviewWebsiteProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int GameReviewId { get; set; }
        public int GamerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    
        public virtual Gamer Gamer { get; set; }
        public virtual GameReview GameReview { get; set; }
    }
}