using System.ComponentModel.DataAnnotations;

namespace MVC_CollegeManagement.ViewModels
{
    public class RegisterViewModel
    {
        /*add a new folder to the project, which we'll call ViewModels.
        Then, in this folder, we will define a new Register View Model class
        that will represent the registering user*/
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Year of birth")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The field {0} must have a minimum of {2} and a maximum of {1} characters.", MinimumLength = 5)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}
