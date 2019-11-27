using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class OrderItemsRepository : BaseDapperRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemsRepository(Connection connection) : base(connection)
        {
        }
    }
}
