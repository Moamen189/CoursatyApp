using CoursatyApp.Entities;

namespace CoursatyApp.Data.Repositories
{
    public class CategoryRepository : BaseRerpository<Category , CoursesDbContext>
    {
        public CategoryRepository(CoursesDbContext dbContext) : base(dbContext)
        {

        }
    }
}
