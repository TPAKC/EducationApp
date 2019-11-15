using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition.Items;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionsService : IPrintingEditionsService
    {
        private readonly IPrintingEditionRepository _printingEditionsrepository;
        public PrintingEditionsService(IPrintingEditionRepository printingEditionRepository)
        {
            _printingEditionsrepository = printingEditionRepository;
        }

        public async Task<GetPrintingEditionsViewModel> GetAll()
        {
            var dbResponse = await _printingEditionsrepository.GetAll();
            var response = new GetPrintingEditionsViewModel();
            response.PrintingEditions = dbResponse.Select(m =>
            {
                var model = new GetPrintingEditionItemModel();
                model.Id = m.Id;
                model.Name = m.Title;
                return model;
            }).ToList();
            return response;
        }
    }
}
