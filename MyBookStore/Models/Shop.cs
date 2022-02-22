using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class Shop
    {

        public int ID { get; set; }
        public Book Book { get; set; }
        public Store Store { get; set; }     
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateSale { get; set; }
    }
}