﻿using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Constants.ServiceValidationErrors;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionService : IPrintingEditionsService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(
            IPrintingEditionRepository printingEditionRepository,
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            IMapper mapper)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
        }

        public async Task<BaseModel> CreateAsync(NewProductModel newProductModel)
        {
            var resultModel = new BaseModel();
            var printingEdition = _mapper.NewProductModelToEntity(newProductModel);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
                return resultModel;
            }

            var resultAdd = await _printingEditionRepository.Add(printingEdition);
            if (resultAdd == 0)
            {
                resultModel.Errors.Add(FailedToCreatePrintingEdition);
            }

            var resultAddRange = await _authorInPrintingEditionRepository.AddRange(newProductModel.AuthorsId, resultAdd);
            if (resultAddRange)
            {
                resultModel.Errors.Add(FailedCreatingСonnection);
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(NewProductModel productModel, long id)
        {
            var resultModel = new BaseModel();
            if (productModel == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
            }

            var printingEdition = _mapper.NewProductModelToEntity(productModel);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(PrintingEditionIsNotFound);
                return resultModel;
            }
            printingEdition.Id = id;
            _authorInPrintingEditionRepository.RemoveByPrintingEdition(id);
            var resultAddRange = await _authorInPrintingEditionRepository.AddRange(productModel.AuthorsId, id);
            if (resultAddRange)
            {
                resultModel.Errors.Add(FailedCreatingСonnection);
            }
            var result = await _printingEditionRepository.Update(printingEdition);
            if (!result)
            {
                resultModel.Errors.Add(FailedToUpdatePrintingEdition);
            }
            return resultModel;
        }
        public async Task<PrintingEditionModelItem> GetAsync(long Id)
        {
            var printingEditionModel = new PrintingEditionModel();
            var filteredModel = _mapper.UserCatalogModelToFilteredModel(catalogModel);
            var responseModels = await _printingEditionRepository.FilteredAsync(filteredModel);
            printingEditionModel.Items = _mapper.ResponseModelsToModelItems(responseModels.ResponseModels, catalogModel.Currency);
            return printingEditionModel;
        }

        public async Task<PrintingEditionModel> GetUserCatalogAsync(UserCatalogModel catalogModel)
        {
            var printingEditionModel = new PrintingEditionModel();
            var filteredModel = _mapper.UserCatalogModelToFilteredModel(catalogModel);
            var responseModels = await _printingEditionRepository.FilteredAsync(filteredModel);
            printingEditionModel.Items = _mapper.ResponseModelsToModelItems(responseModels.ResponseModels, catalogModel.Currency);
            return printingEditionModel;
        }

        public async Task<PrintingEditionModel> GetAdminCatalogAsync(AdminCatalogModel catalogModel)
        {
            var printingEditionModel = new PrintingEditionModel();
            var filteredModel = _mapper.AdminCatalogModelToFilteredModel(catalogModel);
            var responseModels = await _printingEditionRepository.FilteredAsync(filteredModel);
            printingEditionModel.Items = _mapper.ResponseModelsToModelItems(responseModels.ResponseModels, Currency.USD);
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
            _authorInPrintingEditionRepository.RemoveByPrintingEdition(id);

            var resultUpdate = await _printingEditionRepository.Update(printingEdition);
            if (!resultUpdate)
            {
                resultModel.Errors.Add(FailedToRemovePrintingEdition);
            }
            return resultModel;
        }
    }
}
