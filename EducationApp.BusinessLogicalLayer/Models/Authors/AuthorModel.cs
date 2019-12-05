using EducationApp.BusinessLogicalLayer.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.Author
{
    public class AuthorModel : BaseModel
    {
        public List<AuthorModelItem> Items;
    }

    public class AuthorModelItem : BaseModel
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
    }


}
