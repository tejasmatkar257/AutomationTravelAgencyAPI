namespace AutomationTravelAgency.Models.Domain
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public int SeatingCapacity { get; set; }
        public float FarePerKm { get; set; }
    }
}
