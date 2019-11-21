using System;

namespace EducationApp.DataAccessLayer.Entities.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatingDate { get; set; }
    }
}