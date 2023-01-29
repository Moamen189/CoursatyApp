using CoursatyApp.Entities;

namespace CoursatyApp.Data.Repositories
{
    public class CourseRepository :BaseRerpository<Course, CoursesDbContext>
    {
        public CourseRepository(CoursesDbContext dbContext) : base(dbContext)
        {

        }
    }
}
