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
    public class NewsArticleController : ControllerBase
    {
        public INewArticleService service = new NewsArticleService();
        public NewsArticleController()
        {
        }
        [HttpGet("ViewAll")]
        public async Task<IActionResult> ViewAll()
        {
            var result = await service.ViewAllNewsArticle();
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpGet("ViewSearchPaging")]
        public async Task<IActionResult> ViewSearchPaging(string? title, int sizePaging,int indexPaging)
        {
            var result = await service.ViewAllNewsArticleSearchPaging(title, sizePaging, indexPaging);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpGet("ViewDetail")]
        public async Task<IActionResult> ViewDetail(string newsArticleId)
        {
            var result = await service.ViewNewsArticleDetail(newsArticleId);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("ViewStatistic")]
        public async Task<IActionResult> ViewStatistic(DateTime fromDate, DateTime toDate)
        {
            var result = await service.ViewStatistic(fromDate, toDate);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        //[Authorize(Roles = "Staf")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] NewsArticleAdd key)
        {
            var result = await service.AddNewsArticle(key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);*/
        }
        [Authorize(Roles = "Staf")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] NewsArticleUpdate key)
        {
            var result = await service.UpdateNewsArticle(key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
       // [Authorize(Roles = "Staf")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string NewsArticleId)
        {
            var result = await service.DeteleNewsArticle(NewsArticleId);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
    }
}
