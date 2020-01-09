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

        protected IDbConnection Connection { get; set; }

        public BaseDapperRepository(Connection connection)
        {
            Connection = new SqlConnection(connection.ConnectionString);
        }

        public virtual async Task<long> Add(TEntity item)
        {
            return await Connection.InsertAsync(item);
        }

        public virtual async Task<bool> Update(TEntity item)
        {
            return await Connection.UpdateAsync(item); 
        }

        public virtual async Task<bool> Remove(TEntity item)
        {
            return await Connection.DeleteAsync<TEntity>(item);
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
