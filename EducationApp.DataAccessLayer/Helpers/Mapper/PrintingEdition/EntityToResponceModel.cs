using EducationApp.DataAccessLayer.Helpers.Mapper.Interface;
using EducationApp.DataAccessLayer.ResponseModels.Items;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.DataAccessLayer.Helpers.Mapper
{
    public partial class Mapper : IMapper
    {
        public GetAllItemsEditionItemResponseModel EntityToResponceModel(PrintingEdition printingEdition)
        {
            var responceModel = new GetAllItemsEditionItemResponseModel();
            responceModel.Title = printingEdition.Title;
            responceModel.Description = printingEdition.Description;
            responceModel.Price = printingEdition.Price;
            responceModel.Currency = printingEdition.Currency;
            responceModel.Type = printingEdition.Type;
            return responceModel;
        }
    }
}
