using Microsoft.EntityFrameworkCore;
using RegistrationForm.Models;

namespace RegistrationForm.Data
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext>options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedData
            modelBuilder.Entity<User>().HasData(
                new User() { id = 1, UserName = "therezmi", Password = "Rezmi2908", Email = "reza2908bahrami@gmail.com", RegisterDate = DateTime.Now }
                );
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
