using MyBookStore.DB_Store;
using MyBookStore.Models;
using System.Linq;
using System.Web.Http;

namespace MyBookStore.Controllers
{
    public class AuthorsController : ApiController
    {
        private DB_MyStore db = new DB_MyStore();


        [HttpGet]
        public IQueryable<Author> Authors()
        {
            return db.Authors;
        }

        [HttpGet]
        public IHttpActionResult AuthorById(int id)
        {
            Author authors = db.Authors.FirstOrDefault(x => x.ID == id);
            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        [HttpPost]
        public IHttpActionResult Author(Author author)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            db.SaveChanges();

            return Ok(author);

        }

        [HttpDelete]
        public IHttpActionResult Author(int id)
        {

            Author authors = db.Authors.FirstOrDefault(x => x.ID == id);
            if (authors == null)
            {
                return NotFound();

            }

            db.Authors.Remove(authors);
            db.SaveChangesAsync();

            return Ok(authors);


        }




    }
}
