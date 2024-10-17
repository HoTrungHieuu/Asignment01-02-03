using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessObject.Models;
using BussinessObject.ViewModel;
using Service.Service;
using System.Text.Json;
using System.Net.Http.Headers;
using BussinessObject.UpdateModel;

namespace FE.Pages
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public NewsArticleView NewsArticle { get; set; } = default!;
        public NewsArticleUpdate NewsArticleUpdate { get; set; } = default!;
         public List<TagView> Tags { get; set; } = new List<TagView>();
        public List<CategoryView> Categories { get; set; } = new List<CategoryView>();
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var token = HttpContext.Session.GetString("Token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Fetch NewsArticle details
            var response = await _httpClient.GetAsync($"https://localhost:7257/api/NewsArticle/ViewDetail?newsArticleId={id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResult>();
                if (result != null && result.Status == 200)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    NewsArticle = JsonSerializer.Deserialize<NewsArticleView>(result.Data.ToString(), options);

                    // Fetch Categories
                    var categoryResponse = await _httpClient.GetAsync("https://localhost:7257/api/Category/GetAll");
                    if (categoryResponse.IsSuccessStatusCode)
                    {
                        var categories = await categoryResponse.Content.ReadFromJsonAsync<List<CategoryView>>();
                        Categories = categories ?? new List<CategoryView>();

                        //ViewBag.Category = new SelectList(Categories, "Id", "Name", NewsArticle.Category.CategoryId);
                    }

                    // Fetch Tags
                    var tagResponse = await _httpClient.GetAsync("https://localhost:7257/api/Tag/GetAll");
                    if (tagResponse.IsSuccessStatusCode)
                    {
                        var tags = await tagResponse.Content.ReadFromJsonAsync<List<TagView>>();
                        Tags = tags ?? new List<TagView>();

                        //ViewBag.ListTags = new SelectList(Tags, "Id", "Name", NewsArticle.ListTags);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

    }
}
