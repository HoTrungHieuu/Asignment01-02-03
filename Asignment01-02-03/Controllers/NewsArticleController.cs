﻿using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
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
        [HttpPost("Add")]
        public async Task<IActionResult> Add(short accountId, [FromBody] NewsArticleAdd key)
        {
            var result = await service.AddNewsArticle(accountId, key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(short accountId, [FromBody] NewsArticleUpdate key)
        {
            var result = await service.UpdateNewsArticle(accountId, key);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int NewsArticleId)
        {
            var result = await service.DeteleNewsArticle(NewsArticleId);
            if (result.Status == 200) return Ok(result);
            else return BadRequest(result);
        }
    }
}
