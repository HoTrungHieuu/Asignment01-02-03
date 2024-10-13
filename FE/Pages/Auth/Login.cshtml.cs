using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Plugins;
using System.Text.Json;
using Service.Service;


namespace FE.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7257/"); 

        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // X? l? n?u c� y�u c?u khi t?i trang
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // �?nh ngh?a URL cho API Login
            var url = $"api/Account/Login?email={Email}&password={Password}";

            // G?i API
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // �?c ph?n h?i t? API
                var result = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<ServiceResult>(result);

                // �i?u h�?ng �?n trang ch�nh sau khi ��ng nh?p th�nh c�ng
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "��ng nh?p th?t b?i. Vui l?ng ki?m tra l?i th�ng tin.";
                return Page();
            }
        }
    }
}
