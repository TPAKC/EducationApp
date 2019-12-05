using EducationApp.BusinessLogicalLayer.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition
{
    public class PrintingEditionModelItem
    {
        [Required]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public StatusPrintingEdition Status { get; set; } //todo ProductStatus +
        public CurrencyPrintingEdition Currency { get; set; }
        public TypePrintingEdition Type { get; set; } //todo add enums to BLL +
    }

    public class PrintingEditionModel
    {
        public List<PrintingEditionModelItem> PrintingEditions;
    }
}