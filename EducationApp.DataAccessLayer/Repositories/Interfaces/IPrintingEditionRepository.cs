using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.ResponseModels.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IPrintingEditionRepository
    {
        Task<long> Add(PrintingEdition item);
        Task<PrintingEdition> Find(long id);
        Task<List<PrintingEdition>> GetAll();
        Task<bool> Remove(PrintingEdition item);
        Task<bool> Update(PrintingEdition item);
        Task<List<GetAllItemsEditionItemResponseModel>> FilteredAsync(bool[] categorys);
    }
}
