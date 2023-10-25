using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> tbl_category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Ahmad", DisplayOrder = 3 },
                new Category { Id = 2, Name = "Abdullah", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Talha", DisplayOrder = 1 }
                );
        }
    }
}
