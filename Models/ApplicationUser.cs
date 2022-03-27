using Microsoft.AspNetCore.Identity;

namespace MVC_Start.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string City { get; set; }
    }
}
