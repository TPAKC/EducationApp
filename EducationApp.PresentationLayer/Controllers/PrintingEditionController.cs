using AutoMapper;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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