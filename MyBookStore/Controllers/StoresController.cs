using MyBookStore.DB_Store;
using MyBookStore.Models;
using System.Linq;
using System.Web.Http;

namespace MyBookStore.Controllers
{
    public class StoresController : ApiController
    {

        private DB_MyStore db = new DB_MyStore();


        [HttpGet]
        public IQueryable<Store> Stores()
        {
            return db.Stores;
        }

        [HttpGet]
        public IHttpActionResult StoreById(int id)
        {

            Store store = db.Stores.FirstOrDefault(x => x.ID == id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);

        }

        [HttpPost]
        public IHttpActionResult Store(Store store)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stores.Add(store);
            db.SaveChanges();

            return Ok(store);
        }


        [HttpDelete]
        public IHttpActionResult Store(int id)
        {
            Store store = db.Stores.FirstOrDefault(x => x.ID == id);
            if (store == null)
            {
                return NotFound();
            }


            db.Stores.Remove(store);
            db.SaveChangesAsync();

            return Ok(store);

        } 


    }
}
