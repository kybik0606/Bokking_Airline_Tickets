using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bokking_Airline_Tickets.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // Очистка сессии при заходе на страницу логина
            HttpContext.Session.Remove("IsAdmin");
        }

        public IActionResult OnPost()
        {
            // Простейшая проверка логина и пароля
            if (Username == "123" && Password == "123")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToPage("/Admin/Flights");
            }

            ErrorMessage = "Неверный логин или пароль";
            return Page();
        }
    }
}
