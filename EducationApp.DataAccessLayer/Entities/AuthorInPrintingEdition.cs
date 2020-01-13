using EducationApp.DataAccessLayer.Entities.Base;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public long AuthorId { get; set; } 
        public long PrintingEditionId { get; set; }

      //должен работать с ентити а не id
    }
}
