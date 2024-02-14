namespace AutomationTravelAgency.Models.DTO
{
    public class CreateVehicleRequestDto
    {
        public string VehicleName { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public int SeatingCapacity { get; set; }
        public float FarePerKm { get; set; }
    }
}
