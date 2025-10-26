using System;
using System.ComponentModel.DataAnnotations;

namespace Bokking_Airline_Tickets.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Откуда")]
        public string DepartureCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Куда")]
        public string ArrivalCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Дата вылета")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Дата возврата")]
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Range(1, 100000, ErrorMessage = "Цена должна быть от 1 до 100000")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Range(1, 500, ErrorMessage = "Количество мест должно быть от 1 до 500")]
        [Display(Name = "Количество мест")]
        public int AvailableSeats { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Авиакомпания")]
        public string Airline { get; set; } = string.Empty;

        [Display(Name = "Длительность полета (часы)")]
        public int FlightDuration { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; } = true;
    }
}