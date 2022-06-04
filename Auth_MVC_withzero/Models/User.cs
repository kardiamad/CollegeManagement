using Microsoft.AspNetCore.Identity;

namespace MVC_CollegeManagement.Models
{
    public class User : IdentityUser
    {
        /*The User class represents the user and inherits from the 
        IdentityUser class, taking over all its properties.In addition, 
        for example, the Year property has been added here, which will 
        represent the user's year of birth. If desired, you can define 
        any other properties.*/
        public int Year { get; set; }
    }
}
