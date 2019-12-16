using EducationApp.DataAccessLayer.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        Task<long> Add(TEntity item);
        Task AddRange(List<TEntity> item);
        Task UpdateRange(List<TEntity> items);
        Task DeleteRange(List<TEntity> entities);
        Task<TEntity> Find(long id);
        Task<List<TEntity>> GetAll();
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
}
