namespace AutomationTravelAgency.Models.DTO
{
    public class CreateDriverRequestDto
    {
        public string DriverName { get; set; }
        public string DriverAddress { get; set; }
        public long DriverContact { get; set; }
        public string DriverLicenseNumber { get; set; }
    }
}
