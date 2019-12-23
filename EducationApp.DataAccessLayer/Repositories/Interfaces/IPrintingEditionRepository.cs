using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository: IBaseRepository<PrintingEdition>
    {
        Task<List<PrintingEdition>> GetAll(bool[] categorys);
    }
}
