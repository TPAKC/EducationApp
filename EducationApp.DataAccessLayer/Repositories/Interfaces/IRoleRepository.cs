using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IRoleRepository
    {

        Task<IdentityResult> Create(IdentityRole role);
        Task<IdentityResult> Delete(IdentityRole role);
        Task<IdentityRole> FindById(string id);
        Task<IdentityRole> FindByName(string name);
        Task<bool> RoleExists(string name);
        Task<IdentityResult> Update(IdentityRole role);
        IList<IdentityRole> GetRoles();
    }
}
