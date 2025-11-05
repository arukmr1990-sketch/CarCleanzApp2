using System;
using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BookingDate { get; set; }
    }
}