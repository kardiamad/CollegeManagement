using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_CollegeManagement.Models;

namespace MVC_CollegeManagement.Models
{
    /*Since we use Identity, the data context class will be inherited
     not from DbContext, but from IdentityDbContext*/
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<MVC_CollegeManagement.Models.Feedback> Feedback { get; set; }
    }
}
