using AutoMapper;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionsService : IPrintingEditionsService
    {
        IUnitOfWork Database { get; set; }
        public PrintingEditionsService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task MakePrintingEditionAsync(PrintingEditionModel printingEditionModel)
        {
            PrintingEdition printingEdition = await Database.PrintingEditions.Find(printingEditionModel.Id);

            if (printingEdition == null)
                throw new ValidationException("Printing edition not found");
            await Database.PrintingEditions.Add(printingEdition);
            Database.Save();
        }

        public async Task<IEnumerable<PrintingEditionModel>> GetPrintingEditionsAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PrintingEdition, PrintingEditionModel>()).CreateMapper();
            return mapper.Map<IEnumerable<PrintingEdition>, List<PrintingEditionModel>>(await Database.PrintingEditions.GetAll());
        }

        public async Task<PrintingEditionModel> GetPrintingEditionAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Printing edition id not set");
            var printingEdition = await Database.PrintingEditions.Find(id.Value);
            if (printingEdition == null)
                throw new ValidationException("Printing edition not found");

            return new PrintingEditionModel { Id = printingEdition.Id, Title = printingEdition.Title, Description = printingEdition.Description, Status = printingEdition.Status, Currency = printingEdition.Currency, Type = printingEdition.Type };
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
