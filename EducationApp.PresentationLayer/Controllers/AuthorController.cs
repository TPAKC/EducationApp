using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("authors")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _authorService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(string name)
        {
            var result = await _authorService.CreateAsync(name);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(string name, long id)
        {
            var result = await _authorService.UpdateAsync(name, id);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var result = await _authorService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
