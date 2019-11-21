using EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem.Items;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
   public class OrderItemsService : IOrderItemsService
    {
            private readonly IOrderItemRepository _orderItemsrepository;
            public OrderItemsService(IOrderItemRepository orderItemRepository)
            {
                _orderItemsrepository = orderItemRepository;
            }

            public async Task<OrderItemModel> GetAll()
            {
                var dbResponse = await _orderItemsrepository.GetAll();
                var response = new OrderItemModel();
                response.OrderItems = dbResponse.Select(m =>
                {
                    var model = new OrderItemItemModel();
                    model.Id = m.Id;
                    return model;
                }).ToList();
                return response;
            }
    }
}
