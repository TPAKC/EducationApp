﻿using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public ApplicationUser RegisterModelToEntity(RegistrationModel registerModel)
        {
            var user = new ApplicationUser();
            user.Email = registerModel.Email;
            user.UserName = registerModel.Email;
            user.FirstName = registerModel.FirstName;
            user.LastName = registerModel.LastName;
            return user;  
        }
    }
}
