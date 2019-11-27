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
    public class BaseDapperRepository<TEntity>: IBaseRepository<TEntity> where TEntity: BaseEntity
    {
        protected IDbConnection _connection { get; set; }

        public BaseDapperRepository(Connection connection)
        {
            _connection = new SqlConnection(connection.ConnectionString);
        }

        public virtual async Task<long> Add(TEntity item)
        {
            return await _connection.InsertAsync(item);
        }

        public virtual async Task AddRange(List<TEntity> item)
        {
            await _connection.InsertAsync(item);
        }

        public virtual async Task UpdateRange(List<TEntity> items)
        {
            await _connection.UpdateAsync(items);
        }

        public virtual async Task Update(TEntity item)
        {
            await _connection.UpdateAsync(item);
        }

        public async Task DeleteRange(List<TEntity> entities)
        {
            await _connection.DeleteAsync(entities);
        }

        public virtual async Task Remove(TEntity item)
        {
            await _connection.DeleteAsync<TEntity>(item);
        }

        public virtual async Task<TEntity> Find(long id)
        {
            var result = await _connection.GetAsync<TEntity>(id);
            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return (await _connection.GetAllAsync<TEntity>()).AsList();
        }
    }
}
