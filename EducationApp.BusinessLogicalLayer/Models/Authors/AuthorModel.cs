using EducationApp.BusinessLogicalLayer.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Authors
{
    public class AuthorModel : BaseModel
    {
        public List<AuthorModelItem> Authors;
    }

    public class AuthorModelItem : BaseModel
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
    }


}
