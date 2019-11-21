using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrdersRepository(Connection connection) : base(connection)
        {
        }
    }
}
