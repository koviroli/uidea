using System;
using Microsoft.AspNetCore.Identity;

namespace UIdea.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }

        public int XP { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime DateLastLogin { get; set; }

        public DateTime DateLastUpdate { get; set; }
    }
}
