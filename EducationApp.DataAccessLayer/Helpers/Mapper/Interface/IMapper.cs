using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.ResponseModels.Items;

namespace EducationApp.DataAccessLayer.Helpers.Mapper.Interface
{
    public interface IMapper
    {
        GetAllItemsEditionItemResponseModel EntityToResponceModel(PrintingEdition printingEdition);
    }
}
