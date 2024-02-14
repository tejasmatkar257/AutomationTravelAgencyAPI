namespace AutomationTravelAgency.Models.Domain
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public float Distance { get; set; }
        public int Duration { get; set; }

    }
}
