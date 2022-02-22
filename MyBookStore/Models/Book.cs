using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookStore.Models
{
    public class Book
    {
       
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatDate { get; set; } 
        public virtual Author Author { get; set; }
        public virtual Categoria Categoria { get; set; }

        //public ICollection<Store> Stores { get; set; }

  

    }
}