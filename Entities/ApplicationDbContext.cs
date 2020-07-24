using Microsoft.EntityFrameworkCore;

namespace DevWebsCourseProjectApp.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        // data annotaion alternative/additions go here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // indexes - these can ONLY be added here, not on datanotations
            modelBuilder.Entity<Person>().HasIndex(x => x.PersonId).IsUnique();

            // Multi col index
            modelBuilder.Entity<Person>().HasIndex(x => new { x.PersonId, x.FirstName });

            // Computed column, used to concatinate two columns eg "Dave, Smith"
            modelBuilder.Entity<Person>().Property(x => x.DisplayName).HasComputedColumnSql("[FirstName] + ' , ' + [Surname]");
        }



        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
