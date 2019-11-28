using System;

namespace EducationApp.DataAccessLayer.Entities.Base
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatingDate { get; set; }
    }
}