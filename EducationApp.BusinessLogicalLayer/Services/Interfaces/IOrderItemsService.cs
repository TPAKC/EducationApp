using EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem.Items;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IOrderItemsService
    {
        Task<OrderItemModel> GetAll();
    }
}
