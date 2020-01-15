using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItem :BaseEntity
    {
        public long Amount { get; set; }
        public CurrencyPrintingEdition Currency { get; set; }
        public long? PrintingEditionId { get; set; }
        [ForeignKey("PrintingEditionId")]
        public PrintingEdition PrintingEdition { get; set; }
        public long? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public long Count { get; set; }
    }
}
