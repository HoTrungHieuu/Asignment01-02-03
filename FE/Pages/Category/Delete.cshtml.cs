using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessObject.Models;
using BussinessObject.ViewModel;
using Service.Service;
using System.Text.Json;

namespace FE.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public CategoryView Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"https://localhost:7257/api/Category/ViewDetail?categoryId={id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResult>();
                if (result != null && result.Status == 200)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    Category = JsonSerializer.Deserialize<CategoryView>(result.Data.ToString(), options);
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
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            short idTemp = short.Parse(id);
            var response = await _httpClient.DeleteAsync($"https://localhost:7257/api/Category/Delete?categoryId={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error deleting the news article.");
                return Page();
            }
        }
    }
}
