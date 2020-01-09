using EducationApp.BusinessLogicalLayer.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Authors
{
    public class AuthorModel : BaseModel
    {
        public List<AuthorModelItem> Items = new List<AuthorModelItem>();
    }

    public class AuthorModelItem : BaseModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }


}
