using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class Games
    {
        [Key]
        [Display(Name = "GameID")]
        public int GameID { get; set; }
        
        public int CategoryId { get; set; }
        
        public int ReviewId { get; set; }

        [Display(Name = "Category")]
        public string CategoryType { get; set; }

        [Display(Name = "Review")]
        public string ReviewInput { get; set; }

        [Display(Name = "Game Name")]
        public string GameName { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Time")]
        public DateTime Time { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public virtual Category Category { get; set; }
        public virtual Review Review { get; set; }
    }
}