namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }

        // Use same property names as your views expect
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? CarType { get; set; }
        public string? Address { get; set; }

        public DateTime? BookingDate { get; set; }  // instead of Date

        public string? Status { get; set; }   // optional if used in admin
    }
}
