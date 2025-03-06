using Microsoft.EntityFrameworkCore;
using SuperHero.Models.Entities;

namespace SuperHero.Data
{
    public class ApplicationDbContext : DbContext
    {
        /* public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
         {

         }*/
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //properties for collection we want to store
        public DbSet <Employee> Employees { get; set; }

    }
}
