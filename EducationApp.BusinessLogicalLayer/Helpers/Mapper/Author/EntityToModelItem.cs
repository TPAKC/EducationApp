using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper.Author
{
    public partial class Mapper
    {
        public AuthorModelItem EntityToModelItem(Author author)
        {
            var authorModel = new AuthorModelItem
            {
                Name = author.Name
            };
            return authorModel;
        }
    }
}
