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

        public async Task<PrintingEditionModel> GetAll()
        {
            var dbResponse = await _printingEditionsrepository.GetAll();
            var response = new PrintingEditionModel();
            response.PrintingEditions = dbResponse.Select(m =>
            {
                var model = new PrintingEditionItemModel();
                model.Id = m.Id;
                return model;
            }).ToList();
            return response;
        }
    }
}
