using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameReviewWebsiteProject.Models
{
    [MetadataType(typeof(AuthorMetaData))]
    public partial class Author
    {
        public class AuthorMetaData
        {
            public int AuthorId { get; set; }
            [StringLength(150)]
            [Required]
            public string Name { get; set; }
            [Required]
            [StringLength(150)]
            public string Genre { get; set; }
            [Required]
            [StringLength(4000)]
            public string Biography { get; set; }
        }
    }
}
