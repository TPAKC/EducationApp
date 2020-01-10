using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper
{
    public partial class Mapper
    {
        public AuthorModelItem EntityToModelItem(Author author)
        {
            var authorModel = new AuthorModelItem();
            authorModel.Name = author.Name;
            return authorModel;
        }
    }
}
