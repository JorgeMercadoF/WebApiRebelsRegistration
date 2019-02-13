using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace WebApiRebelsRegistration.Models.Repositories
{
    public class RepositoryRegisterRebelds : JorgeMercadoEntities, IRepositoryRegisterRebelds
    {
        public IQueryable<RegisterRebelds> GetAllRegsiter()
        {
            return this.RegisterRebelds.AsQueryable().Include(r => r.Planets).Include(r => r.Rebelds);
        }

        public RegisterRebelds GetRegister(int RegisterId)
        {
            RegisterRebelds Result = this.GetAllRegsiter().Where(c => c.Id == RegisterId).SingleOrDefault();
            return Result;
        }
    }
}