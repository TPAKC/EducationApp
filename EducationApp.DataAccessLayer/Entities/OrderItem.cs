using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Entities.Base;

namespace EducationApp.DataAccessLayer.Entities
{
    public class OrderItem :BaseEntity
    {
        public long Amount { get; set; }
        public Currency Currency { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public Order Order { get; set; }
        public long Count { get; set; }
    }
}
