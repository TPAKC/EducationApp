using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IPrintingEditionsService
    {
        Task MakePrintingEditionAsync(PrintingEditionModel printingEditionModel);
        Task<PrintingEditionModel> GetPrintingEditionAsync(int? id);
        Task<IEnumerable<PrintingEditionModel>> GetPrintingEditionsAsync();
        void Dispose();
    }
}
