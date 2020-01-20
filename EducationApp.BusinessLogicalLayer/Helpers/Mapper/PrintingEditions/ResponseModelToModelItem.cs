using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.ResponseModels;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public List<PrintingEditionModelItem> ResponseModelsToModelItems(List<GetAllItemsEditionItemResponseModel> responseModels)
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
                printingEditionModel.Price = responseModel.Price;
                printingEditionModel.Currency = (Currency)responseModel.Currency;
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
