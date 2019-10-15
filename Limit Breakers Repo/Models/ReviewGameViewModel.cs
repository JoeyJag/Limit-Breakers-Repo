using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class ReviewGameViewModel
    {
        [Key]
        public int GameID { get; set; }
        [DisplayName("Game Name")]
        public string Name { get; set; }
        [DisplayName("Review of Game")]
        public string ReviewOfGame { get; set; }
        public int Rating { get; set; }
        

    }
}