using System.Collections.Generic;

namespace EducationApp.BusinessLogicalLayer.Models.Base
{
    public class BaseModel
    {
        public ICollection<string> Errors = new List<string>();
    }
}
