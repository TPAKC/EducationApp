using EducationApp.DataAccessLayer.Entities.Base;
using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.DataAccessLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public Status Status { get; set; }
        public Currency Currency { get; set; }
        public Type Type { get; set; }
    }
}
