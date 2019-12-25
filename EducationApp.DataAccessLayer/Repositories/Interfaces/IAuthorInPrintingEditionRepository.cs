using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository
    {
        Task<long> Add(AuthorInPrintingEdition item);
        Task AddRange(List<AuthorInPrintingEdition> item);
        Task UpdateRange(List<AuthorInPrintingEdition> items);
        Task DeleteRange(List<AuthorInPrintingEdition> entities);
        Task<AuthorInPrintingEdition> Find(long id);
        Task<List<AuthorInPrintingEdition>> GetAll();
        Task Remove(AuthorInPrintingEdition item);
        Task Update(AuthorInPrintingEdition item);
    }
}
