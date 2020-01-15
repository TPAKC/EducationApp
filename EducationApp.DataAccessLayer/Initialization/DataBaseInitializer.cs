using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.PresentationLayer.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace EducationApp.DataAccessLayer.Initialization
{
    public class DataBaseInitializer
    {
        private const string AdminEmail = "admin@gmail.com";
        private const string AdminPassword = "admin@gmail.com";
        private const string UserEmail = "user@gmail.com";
        private const string UserPassword = "_Uu123456";
        private const string RoleAdmin = "admin";
        private const string RoleUser = "user";

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly ApplicationDbContext _context;

        public DataBaseInitializer(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole<long>> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task InitializeAsync()
        {
            if (await _userManager.FindByNameAsync(AdminEmail) == null)
            {
                await СreationRole(RoleAdmin);
                await СreationRole(RoleUser);//Один приватный метод c СreationRole(RoleAdmin)
                await СreationAccount(AdminEmail, AdminPassword, RoleAdmin);
                await СreationAccount(UserEmail, UserPassword, RoleUser);//Один приватный метод c СreationAccount(AdminEmail, AdminPassword, RoleAdmin)
                await Creation

                //Все дальшще сделать тоже приватным методом
                var authorId = _context.Authors.Add(new Author { Name = "Elon Musk" });//локальные константы
                var printingEditionId = _context.PrintingEditions.Add(new PrintingEdition
                {
                    Title = "TestTitle", //локальные константы
                    Description = "TestDescription", //локальные константы
                    Price = 100,
                    Currency = CurrencyPrintingEdition.USD,
                    Type = TypePrintingEdition.Book
                });

                _context.AuthorInPrintingEditions.Add(new AuthorInPrintingEdition
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