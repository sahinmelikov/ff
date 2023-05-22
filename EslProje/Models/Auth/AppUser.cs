using Microsoft.AspNetCore.Identity;

namespace EslProje.Models.Auth
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActive { get;set; }
    }
}
