using BusinessLogic.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TasksProject.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        //second way to check if name is exist or not using custom attribute it implement in server side
        // [UniqeName]
       
        //third way to check if name is exist or not using remote Attribute it implement in client side
        [Remote(action: "ValidateName", controller:"Instructor",AdditionalFields ="id",ErrorMessage ="Name is Already Exist")]
        public string? Name { get; set; }
        
        public decimal Salary { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]

        public string? City { get; set; }
        [Required]

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("int")]
        [Required]
        public int CourseID { get; set; }
        public Course? Course { get; set; }
        public Department? Department { get; set; }
    }
}
