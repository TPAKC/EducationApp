using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Common.Constants.ServiceValidationErrors;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionService : IPrintingEditionsService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly Mapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, Mapper mapper)
        {
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
        }

        public async Task<BaseModel> CreateAsync(PrintingEditionModelItem printingEditionModelItem)
        {
            var resultModel = new BaseModel();
            var printingEdition = _mapper.PrintingEditionModelToPrintingEdition(printingEditionModelItem);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
                return resultModel;
            } 
            var result = await _printingEditionRepository.Add(printingEdition);
            if (result == 0)
            {
                resultModel.Errors.Add(PrintingEditionNotExist);
                return resultModel;
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem, long id)
        {
            var resultModel = new BaseModel();
            if (resultModel == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
            }

            var printingEdition = _mapper.PrintingEditionModelToPrintingEdition(printingEditionModelItem);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(PrintingEditionIsNotFound);
                return resultModel;
            }
            printingEdition.Id = id;
            await _printingEditionRepository.Update(printingEdition);
            return resultModel;
        }

        public async Task<PrintingEditionModel> GetPrintingEditionsAsync(bool[] categorys)
        {
            var printingEditionModel = new PrintingEditionModel();
            var printingEditions = await _printingEditionRepository.GetAll(categorys);
            if (printingEditions == null)
            {
                printingEditionModel.Errors.Add(ListRetrievalError);
                return printingEditionModel;
            }

            printingEditionModel.PrintingEditions = printingEditions.Select(printingEdition => _mapper.PrintingEditionToPrintingEditionModelItem(printingEdition)).ToList();
            return printingEditionModel;
        }

        public async Task<BaseModel> DeleteAsync(long id)
        {
            var resultModel = new BaseModel();
            var printingEdition = await _printingEditionRepository.Find(id);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(PrintingEditionNotExist);
                return resultModel;
            }
            printingEdition.IsRemoved = true;
            await _printingEditionRepository.Update(printingEdition);
            return resultModel;
        }
    }
}
