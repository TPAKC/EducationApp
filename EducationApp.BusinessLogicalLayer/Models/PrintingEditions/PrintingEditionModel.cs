using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class PrintingEditionModelItem : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string Status { get; set; } //todo ProductStatus +
        public int Currency { get; set; }
        public int Type { get; set; } //todo add enums to BLL +
    }

    public class PrintingEditionModel : BaseModel
    {
        public List<PrintingEditionModelItem> PrintingEditions;
    }
}