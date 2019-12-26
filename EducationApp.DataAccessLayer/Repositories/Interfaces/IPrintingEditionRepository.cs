using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository
    {
        Task<long> Add(PrintingEdition item);
        Task<PrintingEdition> Find(long id);
        Task<List<PrintingEdition>> GetAll();
        Task Remove(PrintingEdition item);
        Task Update(PrintingEdition item);
        Task<List<PrintingEdition>> GetAll(bool[] categorys);
    }
}
