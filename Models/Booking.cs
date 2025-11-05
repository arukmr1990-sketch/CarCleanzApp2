using System;
using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CarType { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required]
        public string ServiceType { get; set; }
    }
}