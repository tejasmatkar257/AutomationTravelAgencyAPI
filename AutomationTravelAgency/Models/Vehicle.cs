namespace AutomationTravelAgency.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set;}
        public int SeatingCapacity { get; set; }
        public int FarePerKm { get; set; }
    }
}
