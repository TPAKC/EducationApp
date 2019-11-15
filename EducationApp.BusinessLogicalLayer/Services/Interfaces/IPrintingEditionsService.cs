using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IPrintingEditionsService
    {
        Task<GetPrintingEditionsViewModel> GetAll();
    }
}
