using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CollegeManagement.Models
{
    public class Feedback
    {
        [Key]
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
