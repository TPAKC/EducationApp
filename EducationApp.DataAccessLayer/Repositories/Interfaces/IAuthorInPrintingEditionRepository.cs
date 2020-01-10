using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository
    {
        Task<long> Add(AuthorInPrintingEdition item);
        Task<AuthorInPrintingEdition> Find(long id);
        Task<List<AuthorInPrintingEdition>> GetAll();
        Task<bool> Remove(AuthorInPrintingEdition item);
        Task<bool> Update(AuthorInPrintingEdition item);
        Task<bool> AddRange(List<long> authorsId, long printingEditionId);
        long RemoveByAuthor(long authorId);
        long RemoveByPrintingEdition(long printingEditionId);
    }
}
