using MyBookStore.DB_Store;
using MyBookStore.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MyBookStore.Controllers
{
    public class BooksController : ApiController
    {
        private DB_MyStore db = new DB_MyStore();


        [HttpGet]
        public IQueryable<Book> Books()
        {
            return db.Books;
        }

        [HttpGet]
        public IHttpActionResult BookById(int id)
        {
            Book book = db.Books.FirstOrDefault(x => x.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

        }

        [HttpPost]
        public IHttpActionResult Book(BookRequestModel bookRequestModel)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temp_Author = db.Authors.FirstOrDefault(x => x.ID == bookRequestModel.AuthorID);
            var temp_Categoria = db.Categorias.FirstOrDefault(y => y.ID == bookRequestModel.CategoriaID);

            if (temp_Author == null)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The author with the specified id={0} was not found", bookRequestModel.AuthorID));
            }

            if (temp_Categoria == null)
            {
                return Content(HttpStatusCode.NotFound, String.Format("The Categori with the specified id={0} was not found", bookRequestModel.CategoriaID));
            }

            Book book = new Book()
            {
                Name = bookRequestModel.Name,
                Categoria = temp_Categoria,
                Author = temp_Author,
                CreatDate = bookRequestModel.CreatDate

            };

            db.Books.Add(book);
            db.SaveChanges();

            return Ok(book);

        }

        [HttpDelete]
        public IHttpActionResult Book(int id)
        {
            Book book = db.Books.FirstOrDefault(x => x.ID == id);
            if (book == null)
            {
                return NotFound();

            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);


        }


    }
}
