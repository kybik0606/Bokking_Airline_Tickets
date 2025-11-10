using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Bokking_Airline_Tickets.Pages.Flights
{
    public class BuyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; } // ID рейса

        [BindProperty]
        [Required(ErrorMessage = "¬ведите ‘»ќ")]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "¬ведите дату рождени€")]
        public DateTime BirthDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "¬ведите серию паспорта")]
        public string PassportSeries { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "¬ведите номер паспорта")]
        public string PassportNumber { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "¬ведите номер карты")]
        public string CardNumber { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "¬ведите срок действи€ карты")]
        public string CardExpire { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "¬ведите CVV")]
        public string CardCVV { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // перенаправл€ем на Success и передаем FlightId
            return RedirectToPage("/Flights/Success", new { FlightId = Id });
        }

    }
}
