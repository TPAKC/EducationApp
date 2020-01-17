using EducationApp.DataAccessLayer.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Orders
{
    public class OrderItemModelItem
    {
        [Required]
        public long Id { get; set; }
        public long Amount { get; set; }
        public Currency Currency { get; set; }
        public long PrintingEditionId { get; set; }
        public long OrderId { get; set; }
        public long Count { get; set; }
    }
}