namespace CarCleanz.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? CarType { get; set; }
        public string? Address { get; set; }
        public DateTime? BookingDate { get; set; }
    }
}
