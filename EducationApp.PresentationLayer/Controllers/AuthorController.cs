using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace EducationApp.PresentationLayer.Controllers
{
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _authorService.GetAllAsync();
            if (result.Errors.Count != 0) return Ok(result.Errors);
            return Ok(result.Authors);
        }

        [HttpPost]
        public async Task<ActionResult> Create(string name)
        {
            var result = await _authorService.CreateAsync(name);
            return Ok(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string name, long id)
        {
            var result = await _authorService.UpdateAsync(name, id);
            return Ok(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var result = await _authorService.DeleteAsync(id);
            return Ok(result.Errors);
        }
    }
}
