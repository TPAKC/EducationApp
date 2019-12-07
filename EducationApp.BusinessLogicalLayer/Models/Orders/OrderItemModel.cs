using EducationApp.DataAccessLayer.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Orders
{
    public class OrderItemModel
    {
        [Required]
        public string Id { get; set; }
        public long Amount { get; set; }
        public CurrencyPrintingEdition Currency { get; set; }
        public string PrintingEditionId { get; set; }
        //public Order Order { get; set; } ???
        public long Count { get; set; }
    }
}