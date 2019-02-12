using System.Data.Entity;
using System.Linq;

namespace WebApiRebelsRegistration.Models.Repositories
{
    public class RepositoryRebelds : JorgeMercadoEntities, IRepositoryRebelds
    {
        public IQueryable<Rebelds> GetAllRebelds()
        {
            return this.Rebelds.AsQueryable();
        }

        public Rebelds GetRebeld(int RebeldId)
        {
            Rebelds Result = this.GetAllRebelds().Where(c => c.Id == RebeldId).SingleOrDefault();
            return Result;
        }

        public bool AddRebeld(Rebelds Rebeld)
        {
            this.Rebelds.Add(Rebeld);
            SaveChanges();
            return true;
        }

        public bool UpdateRebeld(Rebelds Rebeld)
        {
            Entry(Rebeld).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public bool DeleteRebeld(Rebelds Rebeld)
        {
            this.Rebelds.Remove(Rebeld);
            SaveChanges();
            return true;
        }
    }
}