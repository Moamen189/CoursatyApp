using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public TEnitiy Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEnitiy> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEnitiy Update(TEnitiy enitiy)
        {
            throw new System.NotImplementedException();
        }
    }
}
