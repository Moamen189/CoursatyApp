using Microsoft.EntityFrameworkCore;

namespace CoursatyApp.Data
{
    public class CoursesDbContext  : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
