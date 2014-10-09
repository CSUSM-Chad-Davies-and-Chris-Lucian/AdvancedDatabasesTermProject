using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameReviewWebsiteProject.Models
{
    [MetadataType(typeof(GameMetaData))]
    public partial class Game
    {
        public class GameMetaData
        {
            public int GameId { get; set; }
            [Required]
            [StringLength(150)]
            public string Title { get; set; }
            [Required]
            [StringLength(4000)]
            public string Description { get; set; }

            public virtual ICollection<GameReview> GameReviews { get; set; }
        }
    }
}
