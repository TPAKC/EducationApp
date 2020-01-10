using Dapper;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.PresentationLayer.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class AuthorInPrintingEditionRepository : BaseDapperRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(Connection connection) : base(connection)
        {
        }

        public void Remove(int authorId)
        {
            var sqlQuery = "DELETE FROM AuthorInPrintingEdition WHERE AuthorId = @authorId";
            Connection.Execute(sqlQuery, new { authorId });
        }
    }
}
