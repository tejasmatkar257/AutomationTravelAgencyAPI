namespace AutomationTravelAgency.Models.Domain
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string BoardingPoint { get; set; }
        public string DropPoint { get; set; }
        public int NoOfPassengers { get; set; }
        public int FarePerKm { get; set; }
        public bool BookingStatus { get; set; }

    }
}
