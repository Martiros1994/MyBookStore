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

        [HttpGet]
        public IQueryable<Book> BooksInAllStores(int? BookId)
        {
            Book book = db.Books.FirstOrDefault(b => b.ID == BookId);
            if (book == null)
            {
                return Enumerable.Empty<Book>().AsQueryable();
            }

            IQueryable<Book> query = db.Shops.Include("Book").Where(x => x.Book.ID == book.ID).Select(y=>y.Book);
       

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
                Price = shopRequestModel.Price

            };


            db.Shops.Add(shop);
            db.SaveChanges();


            return Ok(shop);
        }





    }
}
