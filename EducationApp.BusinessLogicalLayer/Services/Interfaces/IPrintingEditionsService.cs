using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IPrintingEditionsService
    {
        Task<BaseModel> CreateAsync(NewProductModel newProductModel);
        Task<BaseModel> UpdateAsync(NewProductModel newProductModel, long id);
        Task<PrintingEditionModel> GetSortedAsync(FilteredModel filteredModel, PaginationModel paginationModel);
        Task<BaseModel> DeleteAsync(long id);
    }
}
