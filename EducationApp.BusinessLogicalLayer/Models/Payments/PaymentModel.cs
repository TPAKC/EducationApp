using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.Payment
{
    public class PaymentModelItem
    {
        [Required]
        public string Id { get; set; }
        public string TransactionId { get; set; }
    }

    public class PaymentModel
    {
        public List<PaymentModelItem> Payments;
    }
}
