using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public List<PrintingEditionModelItem> Items = new List<PrintingEditionModelItem>();
    }

    public class PrintingEditionModelItem : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public List<string> AuthorsName { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }
    }
}