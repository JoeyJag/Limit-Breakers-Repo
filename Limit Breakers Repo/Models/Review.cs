using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewID { get; set; }

        public string ReviewOfGame{ get; set; }

        public int Rating { get; set; }

        public int GameID { get; set; }
        public virtual GameDetails GameDetails { get; set; }

    }
}