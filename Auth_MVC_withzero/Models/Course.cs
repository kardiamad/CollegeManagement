using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CollegeManagement.Models
{
    public class Course
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
