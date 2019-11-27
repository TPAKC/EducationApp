using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task MakeuserAsync(UserModel user);
        Task<ClaimsIdentity> Authenticate(UserModel userModel);
        Task SetInitialData(UserModel adminModel, List<string> roles);

 /*       Task MakePrintingEditionAsync(PrintingEditionModel printingEditionModel);
        Task<PrintingEditionModel> GetPrintingEditionAsync(int? id);
        Task<IEnumerable<PrintingEditionModel>> GetPrintingEditionsAsync();
        void Dispose();*/
    }
}
