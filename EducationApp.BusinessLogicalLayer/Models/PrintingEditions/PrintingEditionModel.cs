using EducationApp.BusinessLogicalLayer.Models.Base;
using System;
using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public List<PrintingEditionModelItem> Items = new List<PrintingEditionModelItem>();
    }

    public class PrintingEditionModelItem : BaseModel
    {
        public long Id { get; set; }
        public DateTime CreatingDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> AuthorsNames { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }
    }
}