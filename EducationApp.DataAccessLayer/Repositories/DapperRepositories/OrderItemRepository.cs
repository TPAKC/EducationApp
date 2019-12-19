using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class OrderItemRepository : BaseDapperRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(Connection connection) : base()
        {
        }
    }
}
