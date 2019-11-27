using AutoMapper;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.PresentationLayer.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.Repositories.DapperRepositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionService : IPrintingEditionsService
    {
        private IPrintingEditionRepository _printingEditionRepository;
        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository)
        {
            _printingEditionRepository = printingEditionRepository;
        }


    }
}
