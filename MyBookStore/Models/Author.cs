using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookStore.Models
{
    public class Author
    {      
        public int ID { get; set; }      
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

    }
}