using EducationApp.DataAccessLayer.Entities;
using EducationApp.PresentationLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Controllers
{
    public class PrintingEditionController : ControllerBase
    {
        private ApplicationDbContext db;
        public PrintingEditionController(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return Ok(await db.PrintingEditions.ToListAsync());
        }
        public IActionResult Create()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PrintingEdition printingEditions)
        {
            db.PrintingEditions.Add(printingEditions);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}