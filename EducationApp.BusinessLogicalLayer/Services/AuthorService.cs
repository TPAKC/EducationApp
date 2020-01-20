using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Constants.ServiceValidationErrors;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IMapper _mapper;

        public AuthorService(
            IAuthorRepository authorRepository,
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            IMapper mapper)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BaseModel> CreateAsync(string name)
        {
            var resultModel = new BaseModel();
            var author = new Author();
            author.Name = name;
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
            if (author == null)
            {
                resultModel.Errors.Add(AuthorNotFound);
                return resultModel;
            }
            author.Name = name;
            var result = await _authorRepository.Update(author);
            if(!result)
            {
                resultModel.Errors.Add(FailedToUpdateAuthor);
            }
            return resultModel;
        }

        public async Task<BaseModel> DeleteAsync(long id)
        {
            var resultModel = new BaseModel();
            var author = await _authorRepository.Find(id);
            if (author == null)
            {
                resultModel.Errors.Add(AuthorNotFound);
                return resultModel;
            }
            var result = await _authorRepository.Remove(author);
            if (!result)
            {
                resultModel.Errors.Add(FailedToRemoveAuthor);
            }
            _authorInPrintingEditionRepository.RemoveByAuthor(id);
            return resultModel;
        }

        public async Task<AuthorModel> GetAllAsync()  
        {
            var authorResultModel = new AuthorModel();
            var authors = await _authorRepository.GetAll();
            if (authors == null)
            {
                authorResultModel.Errors.Add(ListRetrievalError);
                return authorResultModel;
            }
            authorResultModel.Items = authors.Select(author => _mapper.EntityToModelItem(author)).ToList();
            return authorResultModel;
        }   
    }
}
