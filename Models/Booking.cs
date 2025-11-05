using System;
using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }  // ? Car, Bike, SUV, etc.

        [Display(Name = "Service Type")]
        public string Service { get; set; }      // ? Exterior, Interior, Full Cleaning, etc.

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        public string Status { get; set; } = "Pending";  // Optional
    }
}