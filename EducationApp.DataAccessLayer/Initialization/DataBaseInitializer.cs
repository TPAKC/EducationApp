using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Common.Constants.AccountRole;
using static EducationApp.DataAccessLayer.Common.Constants.InitializeData;

namespace EducationApp.DataAccessLayer.Initialization
{
    public class DataBaseInitializer //todo use DI +
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataBaseInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void СreationRole(string role)
        {
            if (await _roleManager.FindByNameAsync(role) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role)); //todo use enum or const +
            }
        }

        public async void СreationAccount(string email, string password, string role)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        public async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            СreationRole(NameUserRole);
            СreationRole(NameAdminRole);

            if (await _userManager.FindByNameAsync(AdminEmail) == null) //todo if if +
            {
                СreationAccount(AdminEmail, AdminPassword, AdminPassword);
            }

            if (await userManager.FindByNameAsync(UserEmail) == null)
            {
                СreationAccount(UserEmail, UserPassword, UserPassword);
            }

            /* db.PrintingEditions.Add(new PrintingEdition 
            {
                Title = "TestPE",
                Description= "TestDescription",
                Price = 200, 
                Status = Status.Paid, 
                Currency = Currency.USD,
                Type = Type.Book
              });

            db.Authors.Add(new Author { Name = "Elon Musk" });

            db.SaveChanges();*/
        }
    }
}