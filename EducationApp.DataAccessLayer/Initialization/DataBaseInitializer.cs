using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Common.Constants.AccountRole;
using static EducationApp.DataAccessLayer.Common.Constants.InitializeData;

namespace EducationApp.DataAccessLayer.Initialization
{
    public class DataBaseInitializer
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
      /*  private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;*/ //вместо всего этого работать с контекстом

        public DataBaseInitializer(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole<long>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            if (await _userManager.FindByNameAsync(AdminEmail) == null)
            {
                await СreationRole(RoleAdmin);
                await СreationRole(RoleUser);//Один приватный метод c СreationRole(RoleAdmin)
                await СreationAccount(AdminEmail, AdminPassword, RoleAdmin);
                await СreationAccount(UserEmail, UserPassword, RoleUser);//Один приватный метод c СreationAccount(AdminEmail, AdminPassword, RoleAdmin)


                //Все дальшще сделать тоже приватным методом
                var authorId = await _authorRepository.Add(new Author { Name = "Elon Musk" });//локальные константы
                var printingEditionId = await _printingEditionRepository.Add(new PrintingEdition
                {
                    Title = "TestTitle", //локальные константы
                    Description = "TestDescription", //локальные константы
                    Price = 100,
                    Status = StatusPrintingEdition.Paid,
                    Currency = CurrencyPrintingEdition.USD,
                    Type = TypePrintingEdition.Book
                });
                await _authorInPrintingEditionRepository.Add(new AuthorInPrintingEdition
                {
                    AuthorId = authorId,
                    PrintingEditionId = printingEditionId
                });
            }
        }

        private async Task СreationRole(string role)
        {
            await _roleManager.CreateAsync(new IdentityRole<long>(role)); //format document в начале
        }

        private async Task СreationAccount(string email, string password, string role)
        {
            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                FirstName = role,
                LastName = role,
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
    }
}