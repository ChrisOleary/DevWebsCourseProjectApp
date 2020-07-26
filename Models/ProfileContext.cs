using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevWebsCourseProjectApp.Models
{
    public class ProfileContext : IdentityDbContext<ApplicationUser>
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options) // base(options) for dependancy injection
        {
        }

        //public DbSet<Login> Logins { get; set; }
        //public DbSet<Register> Registration { get; set; }
    }
}
