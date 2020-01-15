using EducationApp.DataAccessLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public long? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public long? PrintingEditionId { get; set; }
        [ForeignKey("PrintingEditionId")]
        public PrintingEdition PrintingEdition { get; set; }
    }
}
