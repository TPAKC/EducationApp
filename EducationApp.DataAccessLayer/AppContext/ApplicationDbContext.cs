using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RolesInitializerApp;

namespace EducationApp.PresentationLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Payment> Paymets { get; set; }

        static ApplicationDbContext()
        {
            // Database.SetInitializer<ApplicationDbContext>(new DataBaseInitializer());
            //or
            // await DataBaseInitializer.InitializeAsync(userManager, rolesManager);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

    }
}
