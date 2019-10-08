using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class GameDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }
        public string GameLocation { get; set; }

        public virtual IList<Review> Review { get; set; }

        public virtual IList<News> News { get; set; }

    }
}