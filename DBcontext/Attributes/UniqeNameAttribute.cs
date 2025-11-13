using DBcontext;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Attributes
{
    public class UniqeNameAttribute:ValidationAttribute
    {
     
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) 
            {
                return new ValidationResult("Name is required");
            }
           ApplicationDbContext _dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext))!;
            var entity = _dbContext!.Instructors.FirstOrDefault(e => e.Name == value.ToString());
            if (entity != null)
            {
                return new ValidationResult("Name must be unique");
            }
            return  ValidationResult.Success;

        }
    }
}
