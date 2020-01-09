using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Payments
{
    public class PaymentModel
    {
        public List<PaymentModelItem> Items;
    }

    public class PaymentModelItem
    {
        [Required]
        public long Id { get; set; }
        public long TransactionId { get; set; }
    }
}
