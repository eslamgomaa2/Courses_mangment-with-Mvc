using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Remote(action: "ValidateName", controller: "int",AdditionalFields ="id", ErrorMessage = "Name is Already Exist")]
        public string Name { get; set; }
        [Range(50,100)]
        [Remote(action: "checkdegree",controller:"int",ErrorMessage ="Mindgree is Greater than Degree")]
        public decimal Degree { get; set; }
        [Range (20,50)]
        public string MinDegree { get; set; }
        public string Hours { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<CrsResult>? CrsResults { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }

    }
}
