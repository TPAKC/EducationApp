using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories
{
    public class OrderItemsRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemsRepository(Connection connection) : base(connection)
        {
        }
    }
}
