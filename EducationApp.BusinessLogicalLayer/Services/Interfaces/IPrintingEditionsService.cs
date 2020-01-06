﻿using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IPrintingEditionsService
    {
        Task<BaseModel> CreateAsync(PrintingEditionModelItem printingEditionModelItem);
        Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem, long id);
        Task<PrintingEditionModel> GetPrintingEditionsAsync(bool[] categorys);
        Task<BaseModel> DeleteAsync(long id);
    }
}
