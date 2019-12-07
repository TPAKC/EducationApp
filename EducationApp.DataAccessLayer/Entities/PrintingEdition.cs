using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public StatusPrintingEdition Status { get; set; }
        public CurrencyPrintingEdition Currency { get; set; }
        public TypePrintingEdition Type { get; set; }
    }
}
