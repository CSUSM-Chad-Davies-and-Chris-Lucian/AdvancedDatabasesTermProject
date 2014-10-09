using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameReviewWebsiteProject.Models
{
    [MetadataType(typeof(GamerMetaData))]
    public partial class Gamer
    {
        public class GamerMetaData
        {
            public int GamerId { get; set; }
            [Required]
            [StringLength(150)]
            public string Name { get; set; }
            [Required]
            [StringLength(150)]
            public string AvatarUrl { get; set; }
            [Required]
            [StringLength(4000)]
            public string Biography { get; set; }
            [Required]
            [StringLength(10)]
            public string Password { get; set; }

            public virtual ICollection<Comment> Comments { get; set; }
        }
    }
}
