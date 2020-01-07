using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Orders;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly Mapper _mapper;

        public OrderService(IOrderRepository orderRepository, Mapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseModel> CreateAsync(OrderModelItem orderModelItem)
        {
            var resultModel = new BaseModel();
            var printingEdition = _mapper.PrintingEditionModelToPrintingEdition(orderModelItem);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
                return resultModel;
            }
            var result = await _printingEditionRepository.Add(printingEdition);
            if (result == 0)
            {
                resultModel.Errors.Add(PrintingEditionNotExist);
                return resultModel;
            }
            return resultModel;
        }
    }
}
