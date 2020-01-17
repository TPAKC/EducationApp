using Dapper;
using Dapper.Contrib.Extensions;
using EducationApp.DataAccessLayer.Entities.Base;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Base
{
    public class BaseDapperRepository<TEntity> where TEntity: BaseEntity
    {

        private readonly string _connectionString;

        public BaseDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual async Task<long> Add(TEntity item)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
                return await connection.InsertAsync(item);
        }

        public virtual async Task<bool> Update(TEntity item)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return await connection.UpdateAsync(item); 
        }

        public virtual async Task<bool> Remove(TEntity item)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return await connection.DeleteAsync<TEntity>(item);
        }

        public virtual async Task<TEntity> Find(long id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var result = await connection.GetAsync<TEntity>(id);
            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return (await connection.GetAllAsync<TEntity>()).AsList();
        }
    }
}
