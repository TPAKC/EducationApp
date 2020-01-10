using Dapper;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class AuthorInPrintingEditionRepository : BaseDapperRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(Connection connection) : base(connection)
        {
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
            var sqlQuery = "DELETE FROM AuthorInPrintingEdition WHERE AuthorId = @id";
            return Connection.Execute(sqlQuery, new { id });
        }

        public long RemoveByPrintingEdition(long id)
        {
            var sqlQuery = "DELETE FROM AuthorInPrintingEdition WHERE PrintingEditionId = @id";
            return Connection.Execute(sqlQuery, new { id });
        }

    }
}
