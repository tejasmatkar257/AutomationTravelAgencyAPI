using System.ComponentModel.DataAnnotations;

namespace AutomationTravelAgency.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
    }
}
