﻿using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.ResponseModels;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Helpers.Interface
{
    public interface IMapper 
    {
        UserModelItem EntityToModelITem(ApplicationUser user);
        ApplicationUser ModelItemToEntity(UserModelItem userModel);
        ApplicationUser RegisterModelToEntity(RegistrationModel registerModel);
        AuthorModelItem EntityToModelItem(Author author);
        PrintingEditionModel ResponseModelToModelItem(List<GetAllItemsEditionItemResponseModel> responseModel);
        PrintingEdition NewProductModelToEntity(NewProductModel newProductModel);
    }
}
