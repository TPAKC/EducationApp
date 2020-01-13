using EducationApp.PresentationLayer.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Base
{
    public class BaseEFRepository<TEntity> : IBaseEFRepository //создать
        {
        private readonly ApplicationDbContext _context;

        public BaseEFRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<EntityEntry> Add(TEntity item)
        {
            var result = _context.Add(item);
            await _context.SaveChangesAsync(); // Проверять действия тоже 
            return result;
        }
        
        public virtual async Task<EntityEntry> Update(TEntity item)
        {
            var result = _context.Update(item);
            await _context.SaveChangesAsync(); // Проверять действия тоже 
            return result;
        }

        public virtual async Task<EntityEntry> Remove(TEntity item)
        {
            var result = _context.Remove(item);
            await _context.SaveChangesAsync();// Проверять действия тоже 
            return result;
        }
/*
        public virtual async Task<TEntity> Find(long id)
        {
            var TEntity = await _context.Find(p => p.Id == id);
            var result = _context.Find(id);
            await _context.SaveChangesAsync();
            return result;
       }
    
       public async Task<List<TEntity>> GetAll()
        {
            return await _context<TEntity>.ToListAsync();
        }*/
    }
}
