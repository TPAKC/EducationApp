using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.Author
{
    public class AuthorModelItem
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class AuthorModel
    {
        public List<AuthorModelItem> Authors;
    }
}
