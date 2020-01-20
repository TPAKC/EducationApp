using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.ResponseModels;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public PrintingEditionModel ResponseModelToModelItem(List<GetAllItemsEditionItemResponseModel> responseModels)
        {
            var modelItem = new PrintingEditionModel();
            /* foreach (GetAllItemsEditionItemResponseModel responseModel in responseModels)
             {

             )
                 var modelItem = new PrintingEditionModelItem();
                 modelItem.Title = responseModel.Title;
                 modelItem.Description = responseModel.Description;
                 modelItem.Price = responseModel.Price;
                 modelItem.Currency = (Currency)responseModel.Currency;
                 modelItem.Type = (PrintingEditionType)responseModel.Type;
             }
             return modelItem;
         }
         */
            return modelItem;
        }
    }
}
