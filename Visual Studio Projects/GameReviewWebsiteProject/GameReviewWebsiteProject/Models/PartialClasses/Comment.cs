using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameReviewWebsiteProject.Models
{
    [MetadataType(typeof(CommentMetaData))]
    public partial class Comment
    {
        public class CommentMetaData
        {
            public int CommentId { get; set; }
            [Required]
            public int GameReviewId { get; set; }
            [Required]
            public int GamerId { get; set; }
            [Required]
            [StringLength(150)]
            public string Title { get; set; }
            [Required]
            [StringLength(4000)]
            public string Content { get; set; }

            public virtual Gamer Gamer { get; set; }
            public virtual GameReview GameReview { get; set; }
        }
    }
}
