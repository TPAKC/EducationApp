using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository
    {
        Task<long> Add(PrintingEdition item);
        Task AddRange(List<PrintingEdition> item);
        Task UpdateRange(List<PrintingEdition> items);
        Task DeleteRange(List<PrintingEdition> entities);
        Task<PrintingEdition> Find(long id);
        Task<List<PrintingEdition>> GetAll();
        Task Remove(PrintingEdition item);
        Task Update(PrintingEdition item);
        Task<List<PrintingEdition>> GetAll(bool[] categorys);
    }
}
