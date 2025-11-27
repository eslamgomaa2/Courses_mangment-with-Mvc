using Microsoft.AspNetCore.Identity;

namespace TasksProject.seedingData
{
    public static class Role
    {
        public static List<IdentityRole<int>> Roles()
        {
           return new List<IdentityRole<int>>() 
           {
           new IdentityRole<int>
           {
               Id = 1,
               Name = "Admin",
               NormalizedName = "ADMIN"
           },
           new IdentityRole < int >
           {
               Id = 2,
               Name = "Instructor",
               NormalizedName = "INSTRUCTOR"
           },
           new  IdentityRole < int >
           {
               Id = 3,
               Name = "Trainee",
               NormalizedName = "TRAINEE"
           },
           };
        }
    }
}
