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

        public async Task СreationRole(string role)
        {
            if (await _roleManager.FindByNameAsync(role) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role)); //todo use enum or const +
            }
        }

        public async Task СreationAccount(string email, string password, string role)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true,
                IsBlocked = false,
                IsRemoved = false
            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        public async Task InitializeAsync()
        {
            await СreationRole(NameUserRole);
            await СreationRole(NameAdminRole);

            if (await _userManager.FindByNameAsync(AdminEmail) == null) //todo if if +
            {
                await СreationAccount(AdminEmail, AdminPassword, NameAdminRole);
            }

            if (await _userManager.FindByNameAsync(UserEmail) == null)
            {
                await СreationAccount(UserEmail, UserPassword, NameUserRole);
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