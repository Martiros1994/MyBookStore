using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MyBookStore.Configuration
{
    public class CategoriaConf : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConf()
        {
            HasKey(k => k.ID);
            Property(k => k.Name).IsRequired().HasMaxLength(100);

        }
    
    
    }
}