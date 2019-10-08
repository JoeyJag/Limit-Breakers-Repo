using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limit_Breakers_Repo.Models
{
    public class Cart
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("WishID")]
        public int CartID { get; set; }
        [DisplayName("Game Name")]
        public string GName { get; set; }
        [DisplayName("Category")]
        public string genre { get; set; }
        [DisplayName("Price")]
        public double price { get; set; }
        
    }
}