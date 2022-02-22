using MyBookStore.DB_Store;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBookStore.Controllers
{
    public class ShopsController : ApiController
    {
        private DB_MyStore db = new DB_MyStore();

       
        
        public IQueryable<Store> BookSaleInStores(int? BookID ,DateTime dateTimeFrom, DateTime dateTimeTo)
        {

            Book book = db.Books.FirstOrDefault(b => b.ID == BookID);
            if (book == null)
            {
                return Enumerable.Empty<Store>().AsQueryable();
            }


            IQueryable<Store> query = db.Shops
                .Where(x => x.Book.ID == book.ID && x.DateSale >= dateTimeFrom && x.DateSale <= dateTimeTo)
                .Select(x => x.Store);

            return query;

        }
        
        
        
        
        
        [HttpGet]
        public IQueryable<Book> BooksSalesByDateAndStore(int? StoreID , DateTime dateTimeFrom , DateTime dateTimeTo)
        {
            Store store = db.Stores.FirstOrDefault(b => b.ID == StoreID);
            if (store == null)
            {
                return Enumerable.Empty<Book>().AsQueryable();
            }

            IQueryable<Book> query = db.Shops
                .Where(x => x.Store.ID == store.ID && x.DateSale >= dateTimeFrom && x.DateSale <= dateTimeTo)
                .Select(x => x.Book);
                //.GroupBy(x => x.)
                

             //IQueryable<Book> query = db.Shops.Include("Book").Where(x => x.Book.ID == book.ID).Select(y=>y.Book);


            return query;
        } 


        [HttpPost]
        public IHttpActionResult Shope(ShopRequestModel shopRequestModel)
        {

            var book = db.Books.FirstOrDefault(b => b.ID == shopRequestModel.BookID);
            var store = db.Stores.FirstOrDefault(s => s.ID == shopRequestModel.StoreID);

            if (book == null || store == null)
            {

                return NotFound();

            }


            Shop shop = new Shop()
            {
                Book = book,
                Store = store,
                Price = shopRequestModel.Price,
                Quantity = shopRequestModel.Quantity,
                DateSale = shopRequestModel.DateSale 
            };


            db.Shops.Add(shop);
            db.SaveChanges();


            return Ok(shop);
        }





    }
}
