using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bokking_Airline_Tickets.Data;
using Bokking_Airline_Tickets.Models;

namespace Bokking_Airline_Tickets.Pages.Admin
{
    public class FlightsModel : PageModel
    {
        private readonly AppDbContext _context;

        public FlightsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Flight> Flights { get; set; } = new();

        [BindProperty]
        public Flight NewFlight { get; set; } = new();

        public async Task OnGetAsync()
        {
            Flights = await _context.Flights
                .OrderBy(f => f.Id)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Flights = await _context.Flights.ToListAsync();
                return Page();
            }

            // ������������� ���� ������ �� ������, ���� �� �������
            if (NewFlight.DepartureDate == default)
            {
                NewFlight.DepartureDate = DateTime.Now.AddDays(1);
            }

            NewFlight.IsActive = true;

            _context.Flights.Add(NewFlight);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "���� ������� ��������!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "���� ������� ������!";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleStatusAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                flight.IsActive = !flight.IsActive;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"���� {(flight.IsActive ? "�����������" : "�������������")}!";
            }

            return RedirectToPage();
        }
    }
}