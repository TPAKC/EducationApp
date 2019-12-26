using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<long> Add(Author item);
        Task<Author> Find(long id);
        Task<List<Author>> GetAll();
        Task Remove(Author item);
        Task Update(Author item);
    }
}
