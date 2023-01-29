using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public TEnitiy Delete(int id)
        {
           var course =  dbContext.Set<TEnitiy>().Find(id);
            dbContext.Set<TEnitiy>().Remove(course);

            dbContext.SaveChanges();

            return course;
            
        }

        public TEnitiy Get(int id)
        {
            return dbContext.Set<TEnitiy>().Find(id);
        }

        public IEnumerable<TEnitiy> Get(Expression<Func<TEnitiy, bool>> Predicate)
        {
            return dbContext.Set<TEnitiy>().Where(Predicate).ToList();
        }

        public IEnumerable<TEnitiy> GetAll()
        {
            return dbContext.Set<TEnitiy>().ToList();
        }

        public TEnitiy Update(TEnitiy entity)
        {
            dbContext.Entry<TEnitiy>(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }

        
    }
}
