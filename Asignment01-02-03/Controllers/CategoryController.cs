using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;

namespace Asignment01_02_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService service = new CategoryService();
        public CategoryController()
        {
        }
        [HttpGet("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var result = await service.ViewAllCategory();
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpGet("ViewDetail")]
        public async Task<IActionResult> ViewDetail(short categoryId)
        {
            var result = await service.ViewCategoryDetail(categoryId);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        //[Authorize(Roles = "Staf")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CategoryAdd key)
        {
            var result = await service.AddCategory(key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [Authorize(Roles = "Staf")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryUpdate key)
        {
            var result = await service.UpdateCategory(key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        //[Authorize(Roles = "Staf")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            var result = await service.DeteleCategory(CategoryId);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
    }
}
