using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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