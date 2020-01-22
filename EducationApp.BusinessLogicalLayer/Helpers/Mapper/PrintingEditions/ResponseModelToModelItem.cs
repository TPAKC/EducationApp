using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.ResponseModels;
using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        private readonly Dictionary<Currency, decimal> ExchangeRates = new Dictionary<Currency, decimal>
        {
            { Currency.USD, 1m },
            { Currency.UAH, 24.34m },
            { Currency.EUR, 0.9m },
            { Currency.GBP, 0.77m },
            { Currency.CHF, 0.97m },
            { Currency.JPY, 110m }
        };

        public List<PrintingEditionModelItem> ResponseModelsToModelItems(List<GetAllItemsEditionItemResponseModel> responseModels, Currency currency)
        {
            var modelItem = new List<PrintingEditionModelItem>();
            foreach (GetAllItemsEditionItemResponseModel responseModel in responseModels)
            {
                int index = FindPrintingEdition(modelItem, responseModel.Id);
                if (index != -1)
                {
                    modelItem[index].AuthorsNames.Add(responseModel.AuthorName);
                    continue;
                }
                var printingEditionModel = new PrintingEditionModelItem();
                printingEditionModel.Title = responseModel.Title;
                printingEditionModel.Description = responseModel.Description;
                printingEditionModel.Price = responseModel.Price * ExchangeRates[currency];
                printingEditionModel.Type = (PrintingEditionType)responseModel.Type;
                printingEditionModel.AuthorsNames.Add(responseModel.AuthorName);

                modelItem.Add(printingEditionModel);
            }
            return modelItem;
        }
        public int FindPrintingEdition(List<PrintingEditionModelItem> printingEditions, long printingEditionId)
        {
            for(int i=0;i<printingEditions.Count;i++)
            {
                if (printingEditions[i].Id == printingEditionId) return i;
            }
            return -1;
        }
    }
}
