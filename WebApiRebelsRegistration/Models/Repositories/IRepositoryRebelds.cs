using System.Linq;

namespace WebApiRebelsRegistration.Models.Repositories
{
    public interface IRepositoryRebelds
    {
        IQueryable<Rebelds> GetAllRebelds();
        Rebelds GetRebeld(int RebeldId);
        bool AddRebeld(Rebelds Rebeld);
        bool UpdateRebeld(Rebelds Rebeld);
        bool DeleteRebeld(Rebelds Rebeld);
        void Dispose();
    }
}