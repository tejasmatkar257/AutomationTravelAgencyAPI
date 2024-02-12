using System.ComponentModel.DataAnnotations;

namespace AutomationTravelAgency.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
