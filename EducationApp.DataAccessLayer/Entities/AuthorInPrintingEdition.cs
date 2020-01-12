using EducationApp.DataAccessLayer.Entities.Base;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public long AuthorId { get; set; } 
        public long PrintingEditionId { get; set; }
        //public DateTime Date { get; set; } 
    }
}
