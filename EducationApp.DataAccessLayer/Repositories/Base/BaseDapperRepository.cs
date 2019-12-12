using Dapper;
using Dapper.Contrib.Extensions;
using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Base
{
    public class BaseDapperRepository<TEntity>: IBaseRepository<TEntity> where TEntity: BaseEntity
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public virtual async Task<long> Add(TEntity item)
        {
            //todo using new connection +
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                return await dataBase.InsertAsync(item);
            }
        }

        public virtual async Task AddRange(List<TEntity> item)
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                await dataBase.InsertAsync(item);
            }
        }

        public virtual async Task UpdateRange(List<TEntity> items)
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                await dataBase.UpdateAsync(items);
            }
        }

        public virtual async Task Update(TEntity item)
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                await dataBase.UpdateAsync(item);
            }
        }

        public async Task DeleteRange(List<TEntity> entities)
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                await dataBase.DeleteAsync(entities);
            }
        }

        public virtual async Task Remove(TEntity item)
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                await dataBase.DeleteAsync<TEntity>(item);
            }
        }

        public virtual async Task<TEntity> Find(long id)
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                var result = await dataBase.GetAsync<TEntity>(id);
                return result;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            using (IDbConnection dataBase = new SqlConnection(connectionString))
            {
                return (await dataBase.GetAllAsync<TEntity>()).AsList();
            }
        }
    }
}
