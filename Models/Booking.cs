using System;
using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string HouseType { get; set; }

        [Required]
        public string CarNumber { get; set; }

        public int Price { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}