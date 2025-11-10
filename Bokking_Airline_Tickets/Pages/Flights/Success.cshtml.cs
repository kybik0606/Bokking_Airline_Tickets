using Bokking_Airline_Tickets.Data;
using Bokking_Airline_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bokking_Airline_Tickets.Pages.Flights
{
    public class SuccessModel : PageModel
    {
        private readonly AppDbContext _context;

        public SuccessModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int FlightId { get; set; }

        public Flight? Flight { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (FlightId == 0)
                return RedirectToPage("/Flights/Index"); // если нет Id, возвращаемся к списку рейсов

            Flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == FlightId);

            if (Flight == null)
                return NotFound(); // рейс не найден

            return Page();
        }
    }
}
