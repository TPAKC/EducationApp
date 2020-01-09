using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.BusinessLogicalLayer.Helpers.PrintingEditionMapper
{
    public partial class Mapper : IMapper
    {
        public PrintingEdition ModelItemToEntity(PrintingEditionModelItem modelItem)
        {
            var printingEdition = new PrintingEdition();
            printingEdition.Title = modelItem.Title;
            printingEdition.Description = modelItem.Description;
            printingEdition.Price = modelItem.Price;
            printingEdition.Status = (StatusPrintingEdition)modelItem.Status;
            printingEdition.Currency = (CurrencyPrintingEdition)modelItem.Currency;
            printingEdition.Type = (TypePrintingEdition)modelItem.Type;
            return printingEdition;
        }
    }
}
