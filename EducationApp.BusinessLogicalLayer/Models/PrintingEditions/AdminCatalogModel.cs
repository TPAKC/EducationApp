using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class AdminCatalogModel
    {
        public List<PrintingEditionType> Types { get; set; }
        public SortType SortType { get; set; }
        public PrintingEditionSortColumn SortColumn { get; set; }
        public long Start { get; set; }
        public long Count { get; set; }
    }
}
