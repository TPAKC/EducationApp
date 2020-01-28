using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public PrintingEditionModelItem EntityToModelItem(PrintingEdition printingEdition)
        {
            var modelItem = new PrintingEditionModelItem();
            modelItem.Title = printingEdition.Title;
            modelItem.Description = printingEdition.Description;
            modelItem.Price = printingEdition.Price;
            modelItem.Type = (PrintingEditionType)printingEdition.Type;
            return modelItem;
        }
    }
}
