namespace AutomationTravelAgency.Models
{
    public class Booking
    {
        public int BookingId {  get; set; }
        public string BookingDate  { get; set; }
        public string JourneyDate { get; set;}
        public string Source { get; set; }
        public string Destination { get; set; }
        public string BoardingPoint { get; set; }
        public string DropPoint { get; set; }
        public int NoOfPassengers {  get; set; }
        public int Fare {  get; set; }
        public string BookingStatus { get; set;}

    }
}
