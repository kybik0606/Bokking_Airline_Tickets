using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bokking_Airline_Tickets.Pages.Flights
{
    public class BuyModel : PageModel
    {
        public int FlightId { get; set; }

        public void OnGet(int id)
        {
            FlightId = id;
        }
    }
}
