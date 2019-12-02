using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class RoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> manager)
        {
            _roleManager = manager;
        }

        public async Task<IdentityResult> Create(IdentityRole role)
        {
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> Delete(IdentityRole role)
        {
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<IdentityRole> FindById(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<IdentityRole> FindByName(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task<bool> RoleExists(string name)
        {
            return await _roleManager.RoleExistsAsync(name);
        }

        public async Task<IdentityResult> Update(IdentityRole role)
        {
            return await _roleManager.UpdateAsync(role);
        }

        public IList<IdentityRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
