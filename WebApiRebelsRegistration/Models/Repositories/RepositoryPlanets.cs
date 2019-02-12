using System.Data.Entity;
using System.Linq;

namespace WebApiRebelsRegistration.Models.Repositories
{
    public class RepositoryPlanets : JorgeMercadoEntities, IRepositoryPlanets
    {
        public IQueryable<Planets> GetAllPlanets()
        {
            return this.Planets.AsQueryable();
        }

        public Planets GetPlanet(int PlanetId)
        {
            Planets Result = this.GetAllPlanets().Where(c => c.Id == PlanetId).SingleOrDefault();
            return Result;
        }

        public bool AddPlanet(Planets Planet)
        {
            this.Planets.Add(Planet);
            SaveChanges();
            return true;
        }

        public bool UpdatePlanet(Planets Planet)
        {
            Entry(Planet).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public bool DeletePlanet(Planets Planet)
        {
            this.Planets.Remove(Planet);
            SaveChanges();
            return true;
        }
    }
}