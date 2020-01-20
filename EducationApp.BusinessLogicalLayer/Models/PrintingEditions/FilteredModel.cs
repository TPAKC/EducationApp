using EducationApp.BusinessLogicalLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class FilteredModel
    {
        public List<PrintingEditionType> Types { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public Currency? Currency { get; set; }
        public string SearchText { get; set; }
        public SortType SortType { get; set; }//сделать енум в BLL
        public PrintingEditionSortColumn? SortColumn { get; set; }//сделать енум в BLL
    }
}
