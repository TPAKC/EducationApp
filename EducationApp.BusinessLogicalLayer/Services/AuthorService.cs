using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Common.Constants.ServiceValidationErrors;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly Mapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, Mapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BaseModel> CreateAsync(string name)
        {
            var resultModel = new BaseModel();
            var author = new Author() { Name = name };
            var result = await _authorRepository.Add(author);
            if(result == 0)
            {
                resultModel.Errors.Add(FailedToCreateAuthor);
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(string name, long id)
        {
            var resultModel = new BaseModel();

            var author = await _authorRepository.Find(id);
            author.Name = name;
            await _authorRepository.Update(author);// add exc error
            return resultModel;
        }
        public async Task<BaseModel> DeleteAsync(long id)
        {
            var resultModel = new BaseModel();
            var author = await _authorRepository.Find(id);
            await _authorRepository.Remove(author);// add exc error
            return resultModel;
        }

        public async Task<AuthorModel> GetAuthorsAsync()  
        {
            var authorResultModel = new AuthorModel();
            var authors = await _authorRepository.GetAll();
            if (authors == null)
            {
                authorResultModel.Errors.Add(ListRetrievalError);
                return authorResultModel;
            }
            authorResultModel.Authors = authors.Select(author => _mapper.AuthorToAuthorModelItem(author)).ToList();
            return authorResultModel;
        }   
    }
}
