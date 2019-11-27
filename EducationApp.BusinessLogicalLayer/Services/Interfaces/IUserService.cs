using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(UserModel user);
    }
}
