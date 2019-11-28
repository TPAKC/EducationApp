using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.PrintingEdition
{
    public class PrintingEditionModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public Status Status { get; set; }
        public Currency Currency { get; set; }
        public Type Type { get; set; }
    }
}