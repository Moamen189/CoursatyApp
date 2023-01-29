using Microsoft.EntityFrameworkCore;

namespace CoursatyApp.Data.Repositories
{
    public class BaseRerpository<TEnitiy , IDbContext> : IRepository<TEnitiy>
        where TEnitiy : class
        where IDbContext :DbContext
    {
        private readonly IDbContext dbContext;

        public BaseRerpository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TEnitiy Add(TEnitiy entity)
        {
            dbContext.Set<TEnitiy>().Add(entity);

            dbContext.SaveChanges();    

            return entity;
        }
    }
}
