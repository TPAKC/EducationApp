using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Controllers
{
    public class PrintingEditionController : ControllerBase
    {

        private readonly IPrintingEditionsService _printingEditionsService;

        public PrintingEditionController(IPrintingEditionsService printingEditionsService)
        {
            _printingEditionsService = printingEditionsService;
        }

        [HttpGet("printingEditions")]
        public async Task<ActionResult> GetPrintingEditions(bool[] categorys)
        {
            var result = await _printingEditionsService.GetPrintingEditionsAsync(categorys);
            if (result.Errors.Count != 0) return Ok(result.Errors);
            return Ok(result.PrintingEditions);
        }

        /*public async Task<ActionResult> IndexAsync()
        {
            IEnumerable<PrintingEditionModel> printingEditionModels = await pintingEditionsService.GetPrintingEditionsAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PrintingEditionModel, PrintingEdition>()).CreateMapper();
            var printingEdition = mapper.Map<IEnumerable<PrintingEditionModel>, List<PrintingEdition>>(printingEditionModels);
            return Ok(printingEdition);
        }*/
    }
}