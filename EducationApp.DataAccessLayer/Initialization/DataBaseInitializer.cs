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
        private const string NameAuthor = "Elon Musk";
        private const string NameTitle = "Test title";
        private const string NameDescription = "Test description";
        private const decimal Price = 100;

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
                await СreationRole();
                await СreationAccount();
                var authorId = CreationAuthor();
                var printingEditionId = CreationPrintingEdition();
                CreationAuthorInPrintingEdition(authorId, printingEditionId);
            }
        }

        private async Task СreationRole()
        {
            await _roleManager.CreateAsync(new IdentityRole<long>(RoleAdmin));
            await _roleManager.CreateAsync(new IdentityRole<long>(RoleUser));
        }

        private async Task СreationAccount()
        {
            var user = new ApplicationUser();
            user.Email = UserEmail;
            user.UserName = UserEmail;
            user.FirstName = RoleUser;
            user.LastName = RoleUser;
            user.EmailConfirmed = true;
            user.IsBlocked = false;
            user.IsRemoved = false;

            var result = await _userManager.CreateAsync(user, UserPassword);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleUser);
            }

            user = new ApplicationUser();
            user.Email = AdminEmail;
            user.UserName = AdminEmail;
            user.FirstName = RoleAdmin;
            user.LastName = RoleAdmin;

            result = await _userManager.CreateAsync(user, AdminPassword);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleAdmin);
            }
        }

        private long CreationAuthor()
        {
            var author = new Author();
            author.Name = NameAuthor;
            _context.Authors.Add(author);
            return author.Id;
        }
        private long CreationPrintingEdition()
        {
            var printingEdition = new PrintingEdition();
            printingEdition.Title = NameTitle;
            printingEdition.Description = NameDescription;
            printingEdition.Price = Price;
            printingEdition.Currency = CurrencyPrintingEdition.USD;
            printingEdition.Type = TypePrintingEdition.Book;

            _context.PrintingEditions.Add(printingEdition);
            return printingEdition.Id;
        }

        private void CreationAuthorInPrintingEdition(long authorId, long printingEditionId)
        {
            var authorInPrintingEdition = new AuthorInPrintingEdition();
            authorInPrintingEdition.AuthorId = authorId;
            authorInPrintingEdition.PrintingEditionId = printingEditionId;
            _context.AuthorInPrintingEditions.Add(authorInPrintingEdition);
        }
    }
}