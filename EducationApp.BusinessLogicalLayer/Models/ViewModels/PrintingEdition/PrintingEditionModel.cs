using EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition.Items;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition
{
    public class PrintingEditionModel
    {
        public PrintingEditionModel()
        {
            PrintingEditions = new List<PrintingEditionItemModel>();
        }
        public List<PrintingEditionItemModel> PrintingEditions { get; set; }
    }
}