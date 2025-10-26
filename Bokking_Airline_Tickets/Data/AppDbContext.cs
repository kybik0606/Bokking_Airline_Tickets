using Bokking_Airline_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Bokking_Airline_Tickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Заполняем начальными данными
            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    Id = 1,
                    DepartureCity = "Москва",
                    ArrivalCity = "Париж",
                    DepartureDate = DateTime.Now.AddDays(1),
                    Price = 12490,
                    AvailableSeats = 150,
                    Airline = "Аэрофлот",
                    FlightDuration = 4,
                    IsActive = true
                },
                new Flight
                {
                    Id = 2,
                    DepartureCity = "Москва",
                    ArrivalCity = "Токио",
                    DepartureDate = DateTime.Now.AddDays(2),
                    Price = 24990,
                    AvailableSeats = 120,
                    Airline = "Japan Airlines",
                    FlightDuration = 10,
                    IsActive = true
                },
                new Flight
                {
                    Id = 3,
                    DepartureCity = "Санкт-Петербург",
                    ArrivalCity = "Нью-Йорк",
                    DepartureDate = DateTime.Now.AddDays(3),
                    Price = 19990,
                    AvailableSeats = 180,
                    Airline = "Delta",
                    FlightDuration = 9,
                    IsActive = true
                }
            );
        }
    }
}