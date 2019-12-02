using EducationApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.Orders
{
    public class OrderModelItem
    {
        [Required]
        public string Id { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public string PaymentId { get; set; }
    }

    public class OrderModel
    {
        public List<OrderModelItem> Orders;
    }
}