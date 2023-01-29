using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoursatyApp.Data.Repositories
{
    public interface IRepository<TEnitiy> 
    {
        TEnitiy Add(TEnitiy enitiy);
        TEnitiy Update(TEnitiy entity);

        TEnitiy Get(int id);
       IEnumerable<TEnitiy> Get(Expression<Func<TEnitiy, bool>> Predicate);


        TEnitiy Delete(int id);

        IEnumerable<TEnitiy> GetAll();

    }
}
