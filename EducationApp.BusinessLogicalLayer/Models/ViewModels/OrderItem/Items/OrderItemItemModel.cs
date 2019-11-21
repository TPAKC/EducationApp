using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using System;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.OrderItem.Items
{
    public class OrderItemItemModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public Payment Payment { get; set; }
    }
}