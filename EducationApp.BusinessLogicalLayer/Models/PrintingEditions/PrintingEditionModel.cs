using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using EducationApp.BusinessLogicalLayer.Models.Users;
using System;
using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.PrintingEditions
{
    public class PrintingEditionModelItem : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public StatusPrintingEdition Status { get; set; } //todo ProductStatus +
        public CurrencyPrintingEdition Currency { get; set; }
        public TypePrintingEdition Type { get; set; } //todo add enums to BLL +
    }

    public class PrintingEditionModel : BaseModel
    {
        public List<PrintingEditionModelItem> PrintingEditions;

        internal object Select(Func<object, UserModelItem> p)
        {
            throw new NotImplementedException();
        }
    }
}