using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Repositories.DapperRepositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
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
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;

        public DataBaseInitializer(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            PrintingEditionRepository printingEditionRepository, 
            AuthorRepository authorRepository, 
            AuthorInPrintingEditionRepository authorInPrintingEditionRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _printingEditionRepository = printingEditionRepository;
            _authorRepository = authorRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
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

            var authorId = await _authorRepository.Add(new Author { Name = "Elon Musk" });

            var printingEditionId = await _printingEditionRepository.Add(new PrintingEdition
            {
                Title = "TestTitle",
                Description = "TestDescription",
                Price = 100,
                Status = StatusPrintingEdition.Paid,
                Currency = CurrencyPrintingEdition.USD,
                Type = TypePrintingEdition.Book
            });

            await _authorInPrintingEditionRepository.Add(new AuthorInPrintingEdition
            {
             Author = await _authorRepository.Find(authorId),
       PrintingEdition = await _printingEditionRepository.Find(printingEditionId)  
    });



        }
    }
}