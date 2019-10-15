using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsID { get; set; }
        [DisplayName("Patch Number")]
        public string Patch { get; set; }
        public string Announcement { get; set; }
        public int GameID { get; set; }
        public virtual GameDetails GameDetails { get; set; }
    }
}