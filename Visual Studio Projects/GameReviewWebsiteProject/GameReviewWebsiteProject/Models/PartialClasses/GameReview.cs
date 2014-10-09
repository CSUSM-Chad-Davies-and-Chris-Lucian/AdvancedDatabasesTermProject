using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameReviewWebsiteProject.Models
{
    [MetadataType(typeof(GameReviewMetaData))]
    public partial class GameReview
    {
        public class GameReviewMetaData
        {
            public int GameReviewId { get; set; }
            [Required]
            public int GameId { get; set; }
            [Required]
            public int AuthorId { get; set; }
            [Required]
            [StringLength(150)]
            public string Title { get; set; }
            [Required]
            [StringLength(4000)]
            public string Content { get; set; }
            [Required]
            [Range(typeof(Decimal), "1.0", "5.0")]
            public decimal Rating { get; set; }

            public virtual Author Author { get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
            public virtual Game Game { get; set; }
        }
    }
}
