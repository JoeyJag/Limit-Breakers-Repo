using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; }
        public ICollection<Games> Games { get; set; }
    }
}