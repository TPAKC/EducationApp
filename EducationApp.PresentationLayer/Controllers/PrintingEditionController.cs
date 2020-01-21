using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintingEditionController : ControllerBase
    {

        private readonly IPrintingEditionsService _printingEditionsService;

        public PrintingEditionController(IPrintingEditionsService printingEditionsService)
        {
            _printingEditionsService = printingEditionsService;
        }

        [HttpPost("G")]
        public async Task<ActionResult> GetAll(FilteredModel filteredModel, PaginationModel paginationModel)
        {
            var result = await _printingEditionsService.GetSortedAsync(filteredModel, paginationModel);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewProductModel newProductModel)
        {
            var result = await _printingEditionsService.CreateAsync(newProductModel);
            return Ok(result.Errors);
        }
        /*
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(PrintingEditionModelItem printingEditionModelItem, long id)
        {
            var result = await _printingEditionsService.UpdateAsync(printingEditionModelItem, id);
            return Ok(result.Errors);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var result = await _printingEditionsService.DeleteAsync(id);
            return Ok(result.Errors);
        }*/
    }
}