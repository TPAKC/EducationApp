using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<BaseModel> CreateAsync(string name);

        Task<BaseModel> UpdateAsync(string name, long id);
        Task<BaseModel> DeleteAsync(long id);

        Task<AuthorModel> GetAuthorsAsync();
    }
}
