using System.ComponentModel.DataAnnotations;

namespace CarCleanz.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? VehicleType { get; set; }
        public string? ServicePackage { get; set; }
        public string? BookingDate { get; set; }
    }
}