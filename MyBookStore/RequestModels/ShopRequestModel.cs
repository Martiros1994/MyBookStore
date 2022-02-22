using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class ShopRequestModel 
    {
        [Required]
        public int BookID { get; set; }

        [Required]
        public int StoreID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime DateSale { get; set; }
    }
}