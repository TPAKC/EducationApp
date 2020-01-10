using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper
{
    public partial class Mapper : IMapper
    {
        public PrintingEditionModelItem EntityToModelItem(PrintingEdition printingEdition)
        {
            var modelItem = new PrintingEditionModelItem();
            modelItem.Title = printingEdition.Title;
            modelItem.Description = printingEdition.Description;
            modelItem.Price = printingEdition.Price;
            modelItem.Currency = (Currency)printingEdition.Currency;
            modelItem.Type = (PrintingEditionType)printingEdition.Type;
            return modelItem;
        }
    }
}
