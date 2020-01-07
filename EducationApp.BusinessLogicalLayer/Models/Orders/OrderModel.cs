using EducationApp.BusinessLogicalLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Orders
{
    public class OrderModelItem
    {
        [Required]
        public long Id { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }

    public class OrderModel
    {
        public List<OrderModelItem> Items = new List<OrderModelItem>();
    }
}