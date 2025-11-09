using Bokking_Airline_Tickets.Data;
using Bokking_Airline_Tickets.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bokking_Airline_Tickets.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }


        public List<Flight> Flights { get; set; } = new List<Flight>();

        public void OnGet()
        {

            Flights = _context.Flights.ToList();
        }


        public Flight? GetFlightByRoute(string departure, string arrival)
        {
            return Flights.FirstOrDefault(f =>
                f.DepartureCity.Equals(departure, StringComparison.OrdinalIgnoreCase)
                && f.ArrivalCity.Equals(arrival, StringComparison.OrdinalIgnoreCase));
        }
    }
}
