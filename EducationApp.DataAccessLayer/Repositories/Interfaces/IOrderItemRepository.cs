using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<long> Add(OrderItem item);
        Task<OrderItem> Find(long id);
        Task<List<OrderItem>> GetAll();
        Task<bool> Remove(OrderItem item);
        Task<bool> Update(OrderItem item);
    }
}
