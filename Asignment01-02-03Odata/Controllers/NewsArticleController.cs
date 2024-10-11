using BussinessObject.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData;
using Service.IService;
using Service.Service;

namespace Asignment01_02_03Odata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticleController : ODataController
    {
        public INewArticleService service = new NewsArticleService();
        public NewsArticleController()
        {

        }
        [HttpGet("ViewAll")]
        [EnableQuery]
        public async Task<IActionResult> ViewAll()
        {
            try
            {
                var result = await service.ViewAllNewsArticle();
                return Ok((List<NewsArticleView>)result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ViewSearchPaging")]
        [EnableQuery]
        public async Task<IActionResult> ViewSearchPaging(string? title, int sizePaging, int indexPaging)
        {
            try
            {
                var result = await service.ViewAllNewsArticleSearchPaging(title,sizePaging,indexPaging);
                return Ok((List<NewsArticleView>)result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
