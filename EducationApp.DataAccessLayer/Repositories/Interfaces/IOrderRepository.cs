using EducationApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderRepository 
    {
        Task<long> Add(Order item);
        Task<Order> Find(long id);
        Task<List<Order>> GetAll();
        Task<bool> Remove(Order item);
        Task<bool> Update(Order item);
    }
}
