using EducationApp.DataAccessLayer.Entities.Base;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public Author Author { get; set; } //todo check +
        public PrintingEdition PrintingEdition { get; set; }
       // public DateTime Date { get; set; }
    }
}
