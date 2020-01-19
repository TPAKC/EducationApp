using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.RequestModels;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using EducationApp.DataAccessLayer.ResponseModels;
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
        Task<GetAllItemsEditionResponceModel> FilteredAsync(FilteredModel filteredModel, PaginationModel paginationModel);
    }
}
