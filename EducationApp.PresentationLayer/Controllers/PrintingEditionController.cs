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

        [HttpPost("GetUserCatalog")]
        public async Task<ActionResult> GetUserCatalog(UserCatalogModel catalogModel)
        {
            var result = await _printingEditionsService.GetUserCatalogAsync(catalogModel);
            return Ok(result);
        }

        [HttpPost("GetAdminCatalog")]
        public async Task<ActionResult> GetAdminCatalog(AdminCatalogModel catalogModel)
        {
            var result = await _printingEditionsService.GetAdminCatalogAsync(catalogModel);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(NewProductModel newProductModel)
        {
            var result = await _printingEditionsService.CreateAsync(newProductModel);
            return Ok(result);
        }
        
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(NewProductModel newProductModel, [FromRoute]long id)
        {
            var result = await _printingEditionsService.UpdateAsync(newProductModel, id);
            return Ok(result);
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute]long id)
        {
            var result = await _printingEditionsService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost("GetItem/{id}")]
        public async Task<ActionResult> GetItem([FromRoute]long id)
        {
            var result = await _printingEditionsService.GetItemAsync(id);
            return Ok(result);
        }
    }
}
