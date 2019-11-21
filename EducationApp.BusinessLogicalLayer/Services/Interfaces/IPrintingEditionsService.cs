using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IPrintingEditionsService
    {
        Task<PrintingEditionModel> GetAll();
    }
}
