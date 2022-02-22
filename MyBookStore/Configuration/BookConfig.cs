using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MyBookStore.Configuration
{
    public class BookConfig : EntityTypeConfiguration<Book>
    {
        public BookConfig()
        {
            HasKey(k => k.ID);
            Property(k => k.Name).IsRequired().HasMaxLength(50);
            Property(k => k.CreatDate).IsRequired();
            //Property(k => k.Author).IsRequired();
            //Property(k => k.Categoria).IsRequired();
        }
    }
}