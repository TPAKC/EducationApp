using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public class Mapper
    {
        private readonly IUserRepository _userRepository;

        public Mapper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModelItem ApplicationUserToUserModelITem(ApplicationUser user)
        {
            var model = new UserModelItem
            {
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return model;
        }

        public ApplicationUser RegisterModelToApplicationUser(CreateModel registerModel)
        {
            var user = new ApplicationUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
            };
            return user;
        }

        public AuthorModelItem AuthorToAuthorModelItem(Author author)
        {
            var authorModel = new AuthorModelItem
            {
                Name = author.Name
            };
            return authorModel;
        }

        public async Task<ApplicationUser> UserModelITemToApplicationUser(UserModelItem userModel)
        {
            var user = await _userRepository.FindByIdAsync(userModel.Id);
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            var code = await _userRepository.GeneratePasswordResetTokenAsync(user);
            if (!String.IsNullOrWhiteSpace(userModel.Pasword)) await _userRepository.ResetPasswordAsync(user, code, userModel.Pasword);
            return user;
        }

        public PrintingEdition PrintingEditionModelToPrintingEdition(PrintingEditionModelItem printingEditionModelItem)
        {
            var printingEdition = new PrintingEdition
            {
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Status = (StatusPrintingEdition)printingEditionModelItem.Status,
                Currency = (CurrencyPrintingEdition)printingEditionModelItem.Currency,
                Type = (TypePrintingEdition)printingEditionModelItem.Type,

            };
            return printingEdition;
        }

        public PrintingEditionModelItem PrintingEditionToPrintingEditionModelItem(PrintingEdition printingEdition)
        {
            var printingEditionModelItem = new PrintingEditionModelItem
            {
                Title = printingEdition.Title,
                Description = printingEdition.Description,
                Price = printingEdition.Price,
                Status = (Models.Enums.StatusPrintingEdition)printingEdition.Status,
                Currency = (Models.Enums.CurrencyPrintingEdition)printingEdition.Currency,
                Type = (Models.Enums.TypePrintingEdition)printingEdition.Type,
            };
            return printingEditionModelItem;
        }
    }
}
