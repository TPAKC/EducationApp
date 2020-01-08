using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper
    {
        public PrintingEdition ModelItemToEntity(PrintingEditionModelItem printingEditionModelItem)
        {
            var printingEdition = new PrintingEdition
            {
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Status = (StatusPrintingEdition)printingEditionModelItem.Status,
                Currency = (CurrencyPrintingEdition)printingEditionModelItem.Currency,
                Type = (TypePrintingEdition)printingEditionModelItem.Type,
            };
            return printingEdition;
        }
    }
}
