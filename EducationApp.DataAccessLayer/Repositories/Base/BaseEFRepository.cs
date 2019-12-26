using EducationApp.PresentationLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Base
{
        public class BaseEFRepository<TEntity> 
        {
        private readonly ApplicationDbContext _context;

        public BaseEFRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task Add(TEntity item)
        {
            var result = _context.Add(item);
            await _context.SaveChangesAsync();
        }
        /*
        public virtual async Task Update(TEntity item)
        {
            await Connection.UpdateAsync(item);
        }

        public virtual async Task Remove(TEntity item)
        {
            await Connection.DeleteAsync<TEntity>(item);
        }

        public virtual async Task<TEntity> Find(long id)
        {
            var result = await Connection.GetAsync<TEntity>(id);
            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return (await Connection.GetAllAsync<TEntity>()).AsList();
        }*/
    }
}
