using MyBookStore.Models;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Configuration
{
    public class AuthorConfig : EntityTypeConfiguration<Author>
    {

        public  AuthorConfig(){

            HasKey(k => k.ID);
            Property(k => k.Name).IsRequired();
            Property(k => k.Surname).IsRequired().HasMaxLength(50);

        }




    }
}