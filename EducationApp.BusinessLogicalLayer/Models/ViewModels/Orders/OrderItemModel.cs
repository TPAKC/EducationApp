using EducationApp.DataAccessLayer.Entities;
using System;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.Orders
{
    public class OrderItemModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public Payment Payment { get; set; }
    }
}