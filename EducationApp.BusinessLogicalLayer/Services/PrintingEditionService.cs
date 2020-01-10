using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Constants.ServiceValidationErrors;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionService : IPrintingEditionsService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionyRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(
            IPrintingEditionRepository printingEditionRepository, 
            IAuthorInPrintingEditionRepository authorInPrintingEditionyRepository, 
            IMapper mapper)
        {
            _authorInPrintingEditionyRepository = authorInPrintingEditionyRepository;
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
        }

        public async Task<BaseModel> CreateAsync(PrintingEditionModelItem printingEditionModelItem)
        {
            var resultModel = new BaseModel();
            var printingEdition = _mapper.ModelItemToEntity(printingEditionModelItem);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
                return resultModel;
            }

            foreach(int element in fibNumbers)
            { 
                var authorInPrintingEditiony = new AuthorInPrintingEdition();
                authorInPrintingEditiony.AuthorId = printingEditionModelItem.AuthorId;
                authorInPrintingEditiony.PrintingEditionId = printingEdition.Id;
            }
            var result = await _authorInPrintingEditionyRepository.Add(authorInPrintingEditiony);
            if (result == 0)
            {
                resultModel.Errors.Add(FailedToCreatePrintingEdition);
            }
            result = await _printingEditionRepository.Add(printingEdition);
            if (result == 0)
            {
                resultModel.Errors.Add(FailedToCreatePrintingEdition);
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEditionModelItem, long id)
        {
            var resultModel = new BaseModel();
            if (printingEditionModelItem == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
            }

            var printingEdition = _mapper.ModelItemToEntity(printingEditionModelItem);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(PrintingEditionIsNotFound);
                return resultModel;
            }
            printingEdition.Id = id;
            //update AuthorInPrintEd
            var result = await _printingEditionRepository.Update(printingEdition);
            if (!result)
            {
                resultModel.Errors.Add(FailedToUpdatePrintingEdition);
            }
            return resultModel;
        }

        public async Task<PrintingEditionModel> GetAllAsync(bool[] categorys) //add filter 
        {
            var printingEditionModel = new PrintingEditionModel();
            var printingEditions = await _printingEditionRepository.GetAll(categorys);
            printingEditionModel.Items = printingEditions.Select(printingEdition => _mapper.EntityToModelItem(printingEdition)).ToList();
            return printingEditionModel;
        }

        public async Task<BaseModel> DeleteAsync(long id)
        {
            var resultModel = new BaseModel();
            var printingEdition = await _printingEditionRepository.Find(id);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(PrintingEditionNotFound);
                return resultModel;
            }
            printingEdition.IsRemoved = true;
            for()
            var result = await _printingEditionRepository.Update(printingEdition);
            if (!result)
            {
                resultModel.Errors.Add(FailedToRemovePrintingEdition);
            }
            return resultModel;
        }
    }
}
