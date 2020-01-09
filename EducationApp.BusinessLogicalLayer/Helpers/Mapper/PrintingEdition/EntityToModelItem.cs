using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers.PrintingEditionMapper
{
    public partial class Mapper : IMapper
    {
        public PrintingEditionModelItem EntityToModelItem(PrintingEdition printingEdition)
        {
            var modelItem = new PrintingEditionModelItem();
            modelItem.Title = printingEdition.Title;
            modelItem.Description = printingEdition.Description;
            modelItem.Price = printingEdition.Price;
            modelItem.Status = (PrintingEditionStatus)printingEdition.Status;
            modelItem.Type = (PrintingEditionType)printingEdition.Type;
            return modelItem;
        }
    }
}
