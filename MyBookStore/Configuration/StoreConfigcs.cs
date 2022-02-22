using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MyBookStore.Configuration
{
    public class StoreConfig : EntityTypeConfiguration<Store>
    {
        public StoreConfig()
        {
            HasKey(k => k.ID);
            Property(k => k.Name).IsRequired().HasMaxLength(50);
            Property(k => k.Address).IsRequired().HasMaxLength(100);

        }
    }


}