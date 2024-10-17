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

        public NewsArticleView NewsArticle { get; set; } = new NewsArticleView();
        public NewsArticleUpdate NewsArticleUpdate { get; set; } = new  NewsArticleUpdate();
        public List<TagView> AvailableTags { get; set; } = new List<TagView>();
        public List<CategoryView> AvailableCategories { get; set; } = new List<CategoryView>();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Lấy dữ liệu bài báo
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
            var tagResponse = await _httpClient.GetAsync("https://localhost:7257/api/Tag/ViewAll");
            if (tagResponse.IsSuccessStatusCode)
            {
                var tagResult = await tagResponse.Content.ReadFromJsonAsync<ServiceResult>();
                if (tagResult != null && tagResult.Status == 200)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    AvailableTags = JsonSerializer.Deserialize<List<TagView>>(tagResult.Data.ToString(), options);
                }
            }
            var categoryResponse = await _httpClient.GetAsync("https://localhost:7257/api/Category/ViewAll");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryResult = await categoryResponse.Content.ReadFromJsonAsync<ServiceResult>();
                if (categoryResult != null && categoryResult.Status == 200)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    AvailableCategories = JsonSerializer.Deserialize<List<CategoryView>>(categoryResult.Data.ToString(), options);
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload available tags and categories in case of validation failure
                await LoadAvailableData();
                return Page();
            }

            // Prepare the update model
            var selectedTagIds = Request.Form["selectedTags"].ToArray();
            var selectedTags = selectedTagIds.Select(tagId => new TagView { TagId = int.Parse(tagId) }).ToList();
            var token = HttpContext.Session.GetString("Token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            List<int> listTagId = new List<int>();
            foreach (var selectedTagId in selectedTags)
            {
                listTagId.Add(selectedTagId.TagId);
            }
            NewsArticleUpdate.ListTagId = listTagId;



             // Send the update request to the API
             var updateResponse = await _httpClient.PutAsJsonAsync("https://localhost:7257/api/NewsArticle/Update", NewsArticleUpdate);

            if (updateResponse.IsSuccessStatusCode)
            {
                // Redirect to a success page or the list page
                return RedirectToPage("./NewArtical");
            }

            // If the update failed, reload available data and return the page
            await LoadAvailableData();
            ModelState.AddModelError(string.Empty, "An error occurred while updating the news article.");
            return Page();
        }

        private async Task LoadAvailableData()
        {
            var tagResponse = await _httpClient.GetAsync("https://localhost:7257/api/Tag/ViewAll");
            if (tagResponse.IsSuccessStatusCode)
            {
                var tagResult = await tagResponse.Content.ReadFromJsonAsync<ServiceResult>();
                if (tagResult != null && tagResult.Status == 200)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    AvailableTags = JsonSerializer.Deserialize<List<TagView>>(tagResult.Data.ToString(), options);
                }
            }
            var categoryResponse = await _httpClient.GetAsync("https://localhost:7257/api/Category/ViewAll");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryResult = await categoryResponse.Content.ReadFromJsonAsync<ServiceResult>();
                if (categoryResult != null && categoryResult.Status == 200)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    AvailableCategories = JsonSerializer.Deserialize<List<CategoryView>>(categoryResult.Data.ToString(), options);
                }
            }
        }
    }
}
