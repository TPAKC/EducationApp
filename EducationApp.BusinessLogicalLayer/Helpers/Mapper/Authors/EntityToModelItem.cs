using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public AuthorModelItem EntityToModelItem(Author author)
        {
            var authorModel = new AuthorModelItem();
            authorModel.Name = author.Name;
            return authorModel;
        }
    }
}
