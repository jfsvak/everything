using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EVErything.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
