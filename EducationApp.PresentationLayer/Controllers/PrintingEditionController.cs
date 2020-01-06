﻿using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
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

        [HttpGet]
        public async Task<ActionResult> GetPrintingEditions(bool[] categorys)
        {
            var result = await _printingEditionsService.GetPrintingEditionsAsync(categorys);
            if (result.Errors.Count != 0) return Ok(result.Errors);
            return Ok(result.PrintingEditions);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PrintingEditionModelItem printingEditionModelItem)
        {
            var result = await _printingEditionsService.CreateAsync(printingEditionModelItem);
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