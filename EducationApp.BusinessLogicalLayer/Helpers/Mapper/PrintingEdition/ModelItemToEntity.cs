using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.Models.PrintingEdition;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper
{
    public partial class Mapper : IMapper
    {
        public PrintingEdition NewProductModelToEntity(NewProductModel modelItem)
        {
            var printingEdition = new PrintingEdition();
            printingEdition.Title = modelItem.Title;
            printingEdition.Description = modelItem.Description;
            printingEdition.Price = modelItem.Price;
            printingEdition.Currency = (CurrencyPrintingEdition)modelItem.Currency;
            printingEdition.Type = (TypePrintingEdition)modelItem.Type;
            return printingEdition;
        }
    }
}
