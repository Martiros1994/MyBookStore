using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MyBookStore.Configuration
{
    public class ShopConfig : EntityTypeConfiguration<Shop>
    {
        public ShopConfig()
        {
            HasKey(k => k.ID);
            Property(k => k.Price).IsRequired();
            Property(k => k.Quantity).IsRequired();
            //Property(k => k.Book).IsRequired();
            //Property(k => k.Store).IsRequired();
        }
    }
}