using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using EducationApp.DataAccessLayer.ResponseModels;
using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Helpers.Interface
{
    public interface IMapper 
    {
        UserModelItem EntityToModelITem(ApplicationUser user);
        ApplicationUser ModelItemToEntity(UserModelItem userModel);
        ApplicationUser RegisterModelToEntity(RegistrationModel registerModel);
        AuthorModelItem EntityToModelItem(Author author);
        List<PrintingEditionModelItem> ResponseModelsToModelItems(List<GetAllItemsEditionItemResponseModel> responseModels, Currency currency);
        PrintingEdition NewProductModelToEntity(NewProductModel newProductModel);
        FilteredModel FilteredModel(CatalogModel catalogModel);
    }
}
  