using System;
using EducationApp.DataAccessLayer.Entities.Base;

namespace EducationApp.DataAccessLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public Payment Payment { get; set; }
    }
}
