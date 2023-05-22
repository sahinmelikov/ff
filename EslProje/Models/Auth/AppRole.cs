using Microsoft.AspNetCore.Identity;

namespace EslProje.Models.Auth
{
    public class AppRole:IdentityRole
    {
        public bool IsActivited { get; set; }
    }
}
