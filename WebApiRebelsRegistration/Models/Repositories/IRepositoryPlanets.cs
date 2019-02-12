using System.Linq;

namespace WebApiRebelsRegistration.Models.Repositories
{
    public interface IRepositoryPlanets
    {
        IQueryable<Planets> GetAllPlanets();
        Planets GetPlanet(int PlanetId);
        bool AddPlanet(Planets Planet);
        bool UpdatePlanet(Planets Planet);
        bool DeletePlanet(Planets Planet);
        void Dispose();
    }
}