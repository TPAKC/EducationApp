using EducationApp.DataAccessLayer.Entities.Enums;
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
        public Status Status { get; set; }
        public Currency Currency { get; set; }
        public Type Type { get; set; }
    }

    public class PrintingEditionModel
    {
        public List<PrintingEditionModelItem> PrintingEditions;
    }
}