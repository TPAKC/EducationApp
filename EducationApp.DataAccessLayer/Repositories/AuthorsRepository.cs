using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorsRepository(Connection connection) : base(connection)
        {
        }
    }
}
