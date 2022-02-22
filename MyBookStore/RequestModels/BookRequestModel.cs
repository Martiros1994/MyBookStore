using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookStore.Models
{
    public class BookRequestModel
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatDate { get; set; }
     
        public int AuthorID  { get; set; }

        public int CategoriaID  { get; set; }

    }
}