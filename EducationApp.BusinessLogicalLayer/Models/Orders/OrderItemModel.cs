using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using System;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.Orders
{
    public class OrderItemModel
    {
        public string Id { get; set; }
        public long Amount { get; set; }
        public Currency Currency { get; set; }
        public string PrintingEditionId { get; set; }
        public Order Order { get; set; }
        public long Count { get; set; }
    }
}