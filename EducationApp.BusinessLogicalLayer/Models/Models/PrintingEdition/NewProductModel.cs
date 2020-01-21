using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition
{
    public class NewProductModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<long> AuthorsId { get; set; }
        public Currency Currency { get; set; }    
        public PrintingEditionType Type { get; set; }
    }
}
