using Microsoft.AspNetCore.Identity;

namespace TasksProject.seedingData
{
    public static class MappingUserRole
    {
        public static IdentityUserRole<int> UserRole =new IdentityUserRole<int>() 
        {
            RoleId = 1,
            UserId = 1,
        };
    }
}
