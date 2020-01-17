using Dapper;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class AuthorInPrintingEditionRepository : BaseDapperRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {

        private readonly string _connectionString;

        public AuthorInPrintingEditionRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddRange(List<long> authorsId, long printingEditionId)
        {
            foreach (var authorId in authorsId)
            {
                var authorInPrintingEdition = new AuthorInPrintingEdition();
                authorInPrintingEdition.AuthorId = authorId;
                authorInPrintingEdition.PrintingEditionId = printingEditionId;
                var result = await Add(authorInPrintingEdition);
                if(result == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public long RemoveByAuthor(long id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var sqlQuery = "DELETE FROM AuthorInPrintingEdition WHERE AuthorId = @id";
            return connection.Execute(sqlQuery, new { id });
        }

        public long RemoveByPrintingEdition(long id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var sqlQuery = "DELETE FROM AuthorInPrintingEdition WHERE PrintingEditionId = @id";
            return connection.Execute(sqlQuery, new { id });
        }

    }
}
