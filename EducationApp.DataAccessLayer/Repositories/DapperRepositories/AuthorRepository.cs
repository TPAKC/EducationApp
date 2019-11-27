using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class AuthorRepository : BaseDapperRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Connection connection) : base(connection)
        {
        }
    }
}
