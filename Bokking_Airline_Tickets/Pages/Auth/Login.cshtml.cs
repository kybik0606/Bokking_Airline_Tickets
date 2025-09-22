using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Bokking_Airline_Tickets.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // ⚡ Здесь будет логика проверки пользователя
            if (Username == "admin" && Password == "123")
            {
                // Временно редиректим на главную
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
            return Page();
        }
    }
}
