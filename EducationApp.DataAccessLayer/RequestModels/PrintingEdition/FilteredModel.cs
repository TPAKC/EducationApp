using EducationApp.DataAccessLayer.Entities.Enums;
using System.Collections.Generic;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum;

namespace EducationApp.DataAccessLayer.RequestModels.PrintingEdition
{
    public class FilteredModel
    {
        public List<PrintingEditionType> Types { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public Currency? Currency { get; set; }
        public string SearchText { get; set; }
        public SortType SortType { get; set; }
        public PrintingEditionSortColumn? SortColumn { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }
}
