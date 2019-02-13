using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiRebelsRegistration.Models;

namespace WebApiRebelsRegistration.Controllers
{
    public class RegisterRebeldsAPIController : ApiController
    {
        private JorgeMercadoEntities db = new JorgeMercadoEntities();

        // GET: api/RegisterRebeldsAPI
        public IQueryable<RegisterRebelds> GetRegisterRebelds()
        {
            return db.RegisterRebelds;
        }

        // GET: api/RegisterRebeldsAPI/5
        [ResponseType(typeof(RegisterRebelds))]
        public async Task<IHttpActionResult> GetRegisterRebelds(int id)
        {
            RegisterRebelds registerRebelds = await db.RegisterRebelds.FindAsync(id);
            if (registerRebelds == null)
            {
                return NotFound();
            }

            return Ok(registerRebelds);
        }

        // PUT: api/RegisterRebeldsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegisterRebelds(int id, RegisterRebelds registerRebelds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registerRebelds.Id)
            {
                return BadRequest();
            }

            db.Entry(registerRebelds).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterRebeldsExists(id))
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

        // POST: api/RegisterRebeldsAPI
        [ResponseType(typeof(RegisterRebelds))]
        public async Task<IHttpActionResult> PostRegisterRebelds(RegisterRebelds registerRebelds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegisterRebelds.Add(registerRebelds);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = registerRebelds.Id }, registerRebelds);
        }

        // DELETE: api/RegisterRebeldsAPI/5
        [ResponseType(typeof(RegisterRebelds))]
        public async Task<IHttpActionResult> DeleteRegisterRebelds(int id)
        {
            RegisterRebelds registerRebelds = await db.RegisterRebelds.FindAsync(id);
            if (registerRebelds == null)
            {
                return NotFound();
            }

            db.RegisterRebelds.Remove(registerRebelds);
            await db.SaveChangesAsync();

            return Ok(registerRebelds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterRebeldsExists(int id)
        {
            return db.RegisterRebelds.Count(e => e.Id == id) > 0;
        }
    }
}