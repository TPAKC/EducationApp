using EducationApp.BusinessLogicalLayer.Models.Enums;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition
{
    public class NewProductModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public List<long> AuthorsId { get; set; }
        public Currency Currency { get; set; }    
        public PrintingEditionType Type { get; set; }
    }
}
