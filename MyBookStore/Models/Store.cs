using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookStore.Models
{
    public class Store
    {
        
       
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        //public ICollection<Book> Books { get; set; }


    }
}