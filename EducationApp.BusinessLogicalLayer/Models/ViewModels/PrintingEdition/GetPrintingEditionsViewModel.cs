using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition.Items;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition
{
    public class GetPrintingEditionsViewModel
    {
        public GetPrintingEditionsViewModel()
        {
            PrintingEditions = new List<GetPrintingEditionItemModel>();
        }
        public List<GetPrintingEditionItemModel> PrintingEditions { get; set; }
    }
}
