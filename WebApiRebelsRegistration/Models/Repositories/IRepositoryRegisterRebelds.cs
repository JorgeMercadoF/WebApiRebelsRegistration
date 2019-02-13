using System.Linq;

namespace WebApiRebelsRegistration.Models.Repositories
{
    public interface IRepositoryRegisterRebelds
    {
        IQueryable<RegisterRebelds> GetAllRegsiter();
        RegisterRebelds GetRegister(int RegisterId);
        void Dispose();
    }
}