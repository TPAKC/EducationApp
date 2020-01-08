using EducationApp.BusinessLogicalLayer.Models.Enums;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper
    {
        public PrintingEditionModelItem EntityToModelItem(PrintingEdition printingEdition)
        {
            var printingEditionModelItem = new PrintingEditionModelItem
            {
                Title = printingEdition.Title,
                Description = printingEdition.Description,
                Price = printingEdition.Price,
                Status = (PrintingEditionStatus)printingEdition.Status,
                Currency = (Currency)printingEdition.Currency,
                Type = (PrintingEditionType)printingEdition.Type,
            };
            return printingEditionModelItem;
        }
    }
}
