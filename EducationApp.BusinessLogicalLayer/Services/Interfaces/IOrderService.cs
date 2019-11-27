using EducationApp.BusinessLogicalLayer.Models.ViewModels.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task MakeOrderAsync(OrderModel orderModel);
        Task<OrderModel> GetOrderAsync(int? id);
        Task<IEnumerable<OrderModel>> GetOrdersAsync();
        void Dispose();
    }
}
