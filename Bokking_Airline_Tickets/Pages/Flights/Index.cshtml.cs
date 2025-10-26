using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bokking_Airline_Tickets.Data;
using Bokking_Airline_Tickets.Models;

namespace Bokking_Airline_Tickets.Pages.Flights
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Flight> Flights { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string DepartureCity { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string ArrivalCity { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public DateTime? DepartureDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ReturnDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Passengers { get; set; } = 1;

        public async Task OnGetAsync()
        {
            var query = _context.Flights.Where(f => f.IsActive && f.AvailableSeats >= Passengers);

            if (!string.IsNullOrEmpty(DepartureCity))
                query = query.Where(f => f.DepartureCity.Contains(DepartureCity));

            if (!string.IsNullOrEmpty(ArrivalCity))
                query = query.Where(f => f.ArrivalCity.Contains(ArrivalCity));

            if (DepartureDate.HasValue)
                query = query.Where(f => f.DepartureDate.Date == DepartureDate.Value.Date);

            // Исправление для SQLite - сортируем на клиенте
            var flights = await query.ToListAsync();
            Flights = flights.OrderBy(f => f.Price).ToList();
        }
    }
}