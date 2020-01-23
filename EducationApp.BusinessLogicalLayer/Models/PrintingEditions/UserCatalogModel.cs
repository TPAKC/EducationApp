using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class UserCatalogModel
    {
        public List<PrintingEditionType> Types { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public Currency Currency { get; set; }
        public string SearchText { get; set; }
        public SortType SortType { get; set; }
        public PrintingEditionSortColumn? SortColumn { get; set; }
        public long Start { get; set; }
        public long Count { get; set; }
    }
}
