using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BussinessObject.ViewModel; // Đảm bảo namespace này chính xác
using System.Text.Json;
using Service.Service;

namespace FE.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public NewsArticleView NewsArticle { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

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
                    return NotFound(); // Nếu không có dữ liệu
                }
            }
            else
            {
                return NotFound(); // Nếu API trả về lỗi
            }

            return Page();
        }
    }
}
