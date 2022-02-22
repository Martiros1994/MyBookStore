using MyBookStore.Configuration;
using MyBookStore.Models;
using System.Data.Entity;

namespace MyBookStore.DB_Store
{
    public class DB_MyStore : DbContext
    {
        // Your context has been configured to use a 'DB_MyStore' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MyBookStore.DB_Store.DB_MyStore' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DB_MyStore' 
        // connection string in the application configuration file.
        public DB_MyStore()
            : base("name=DB_MyStore")
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DB_MyStore>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<DB_MyStore>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Configurations.Add(new AuthorConfig());
            modelBuilder.Configurations.Add(new BookConfig());
            modelBuilder.Configurations.Add(new CategoriaConf());
            modelBuilder.Configurations.Add(new StoreConfig());
            modelBuilder.Configurations.Add(new ShopConfig());
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}