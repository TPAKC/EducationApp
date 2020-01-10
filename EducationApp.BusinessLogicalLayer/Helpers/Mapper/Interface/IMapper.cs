using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface
{
    public interface IMapper 
    {
        UserModelItem EntityToModelITem(ApplicationUser user);
        ApplicationUser ModelItemToEntity(UserModelItem userModel);
        ApplicationUser RegisterModelToEntity(RegistrationModel registerModel);
        AuthorModelItem EntityToModelItem(Author author);
        PrintingEditionModelItem EntityToModelItem(PrintingEdition printingEdition);
        PrintingEdition NewProductModelToEntity(NewProductModel newProductModel);
    }
}
