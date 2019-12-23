using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IPrintingEditionsService
    {
        Task<BaseModel> CreateAsync(PrintingEditionModelItem printingEditionModelItem);
        Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem, int id);
        Task<PrintingEditionModel> GetPrintingEditionsAsync(bool[] categorys);
    }
}
