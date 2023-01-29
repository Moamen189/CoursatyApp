using CoursatyApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursatyApp.Data
{
    public class CoursesDbContext  : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
