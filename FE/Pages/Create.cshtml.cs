using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BussinessObject.ViewModel;
using System.Text.Json;
using Service.Service;
using Microsoft.Extensions.Options;

namespace FE.Pages
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public NewsArticleView NewsArticle { get; set; } = new NewsArticleView();
        public List<TagView> Tags { get; set; } = new List<TagView>();
        public List<CategoryView> Categories { get; set; } = new List<CategoryView>();

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7257/api/Tag/ViewAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResult>();
                if (result != null && result.Status == 200)
                {
                    var jsonElement = (JsonElement)result.Data;

                    var tags = JsonSerializer.Deserialize<List<TagView>>(jsonElement);
                }
            }
        }
    }
}
