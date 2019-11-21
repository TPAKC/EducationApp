using EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem.Items;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem
{
    public class OrderItemModel
    {
        public OrderItemModel()
        {
            OrderItems = new List<OrderItemItemModel>();
        }
        public List<OrderItemItemModel> OrderItems { get; set; }
    }
}