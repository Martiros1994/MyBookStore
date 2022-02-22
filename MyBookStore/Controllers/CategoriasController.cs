using MyBookStore.DB_Store;
using MyBookStore.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MyBookStore.Controllers
{
    public class CategoriasController : ApiController
    {
        private DB_MyStore db = new DB_MyStore();

        [HttpGet]
        public IQueryable<Categoria> Categorias()
        {
            return db.Categorias;
        }

        [HttpGet]
        public IHttpActionResult CategoriaById(int id)
        {
            Categoria categoria = db.Categorias.FirstOrDefault(x => x.ID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }


        [HttpPost]
        public IHttpActionResult Categoria(Categoria categoria)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorias.Add(categoria);
            db.SaveChanges();

            return Ok(categoria);

        }

        [HttpPut]
        public IHttpActionResult Categoria(int id , Categoria categoria)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.ID)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);



        }


        [HttpDelete]
        public IHttpActionResult Categoria(int id)
        {
            Categoria categoria = db.Categorias.FirstOrDefault(x => x.ID == id);
            if (categoria == null)
            {
                return NotFound();

            }

            db.Categorias.Remove(categoria);
            db.SaveChanges();

            return Ok(categoria);

        }


        private bool CategoriaExists(int id)
        {
            return db.Categorias.Count(e => e.ID == id) > 0;
        }
    }
}