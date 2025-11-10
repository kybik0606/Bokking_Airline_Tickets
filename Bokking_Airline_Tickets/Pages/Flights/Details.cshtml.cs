using Bokking_Airline_Tickets.Data;
using Bokking_Airline_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Bokking_Airline_Tickets.Pages.Flights
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Flight Flight { get; set; }


        public CityInfo ArrivalCityInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            Flight = _context.Flights.FirstOrDefault(f => f.Id == id);

            if (Flight == null)
                return NotFound();

            string cityFolder = Flight.ArrivalCity.Replace(" ", "_"); 
            ArrivalCityInfo = new CityInfo
            {
                Name = Flight.ArrivalCity,
                Description = $"Откройте для себя красоты и культуру города {Flight.ArrivalCity}. Здесь множество достопримечательностей и интересных мест для туристов.",
                Images = new List<string>
                {
                    $"/images/{cityFolder}/1.jpg",
                    $"/images/{cityFolder}/2.jpg",
                    $"/images/{cityFolder}/3.jpg",
                    $"/images/{cityFolder}/4.jpg"
                }
            };

            return Page();
        }
    }

    public class CityInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
    }
}
