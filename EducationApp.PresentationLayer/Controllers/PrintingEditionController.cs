using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.PresentationLayer.Controllers
{
    public class PrintingEditionController : ControllerBase
    {
        IPrintingEditionsService pintingEditionsService;
        public PrintingEditionController(IPrintingEditionsService serv)
        {
            pintingEditionsService = serv;
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