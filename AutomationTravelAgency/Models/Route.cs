namespace AutomationTravelAgency.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public int Duration {  get; set; }

    }
}
