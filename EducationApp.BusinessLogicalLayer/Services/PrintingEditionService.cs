using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class PrintingEditionService : IPrintingEditionsService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly Mapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository, Mapper mapper)
        {
            _printingEditionRepository = printingEditionRepository;
            _mapper = mapper;
        }

        //public async Task<BaseModel> CreateAsync(PrintingEditionModelItem printingEditionModelItem)
        //{
        //    var resultModel = new BaseModel();
        //    var printingEdition = _mapper.PrintingEditionModelToPrintingEdition(printingEditionModelItem);
        //    if (user != null && user.IsRemoved)
        //    {
        //        // _userRepository.UpdateAsync();
        //        return resultModel;
        //    }
        //    var result = await _userRepository.CreateAsync(newUser, createModel.Password);
        //    if (!result)
        //    {
        //        resultModel.Errors.Add(UserCantBeRegistered);
        //        return resultModel;
        //    }

        //    result = await _userRepository.AddToRoleAsync(newUser, NameUserRole); //todo errors and roles from constants or enums +
        //    if (!result)
        //    {
        //        resultModel.Errors.Add(UserCantBeAddedToRole);
        //    }
        //    resultModel.Id = newUser.Id;
        //    return resultModel;
        //}


    }
}
