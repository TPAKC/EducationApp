using AutoMapper;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.Orders;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task MakeOrderAsync(OrderModel orderModel)
        {
            Order order = await Database.Orders.Find(orderModel.Id);

            if (order == null)
                throw new ValidationException("Order not found");
            await Database.Orders.Add(order);
            Database.Save();
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderModel>>(await Database.Orders.GetAll());
        }

        public async Task<OrderModel> GetOrderAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Order id not set");
            var order = await Database.Orders.Find(id.Value);
            if (order == null)
                throw new ValidationException("Order not found");

            return new OrderModel { Id = order.Id, Description = order.Description, User = order.User, Date = order.Date, Payment = order.Payment };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
