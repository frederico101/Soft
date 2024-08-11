using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soft.Bussiness.Core.Data
{
    public interface IRepository<Tentity>: IDisposable where Tentity: Entity  
    {
        Task Add(Tentity entity);
        Task<Tentity> GetById(Guid id);
        Task<List<Tentity>> GetAll();
        Task Update(Tentity entity);
        Task Delete(Guid id);

        Task<int> SaveChanges();
    }
}
