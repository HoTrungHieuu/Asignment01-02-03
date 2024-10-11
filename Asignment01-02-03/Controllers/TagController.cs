using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.Service;

namespace Asignment01_02_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public ITagService service = new TagService();
        public TagController()
        {
        }
        [HttpGet("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var result = await service.ViewAllTag();
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]TagAdd key)
        {
            var result = await service.AddTag(key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TagUpdate key)
        {
            var result = await service.UpdateTag(key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int tagId)
        {
            var result = await service.DeteleTag(tagId);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
    }
}
