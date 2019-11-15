using Dapper;
using Dapper.Contrib.Extensions;
using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        protected IDbConnection Connection { get; set; }

        public BaseRepository(Connection connection)
        {
            Connection = new SqlConnection(connection.ConnectionString);
        }

        public virtual async Task<long> Add(TEntity item)
        {
            return await Connection.InsertAsync(item);
        }

        public virtual async Task AddRange(List<TEntity> item)
        {
            await Connection.InsertAsync(item);
        }

        public virtual async Task UpdateRange(List<TEntity> items)
        {
            await Connection.UpdateAsync(items);
        }

        public virtual async Task Update(TEntity item)
        {
            await Connection.UpdateAsync(item);
        }

        public async Task DeleteRange(List<TEntity> entities)
        {
            await Connection.DeleteAsync(entities);
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
        }
    }
}
