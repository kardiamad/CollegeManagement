using System.ComponentModel.DataAnnotations;

namespace MVC_CollegeManagement.ViewModels
{
    /*To create a user authorization mechanism in the application, 
    first add a special LoginViewModel model to the project from 
    the previous topic in the ViewModels folder*/
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remeber?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
