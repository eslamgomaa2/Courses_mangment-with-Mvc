using Microsoft.AspNetCore.Identity;
using TasksProject.Data.Entities;

namespace TasksProject.seedingData
{
    public static class AdminAccount
    {
        public static ApplicationUser AdminUser =
        
            new ApplicationUser()
            {
                Id = 1,
                FName = "Admin",
                LName = "Admin",
                UserName = "Admin",
                Address="cairo",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "012152001",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123!")

            };
}
    } 
