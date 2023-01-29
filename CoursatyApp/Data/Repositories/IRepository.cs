using System.Collections;
using System.Collections.Generic;

namespace CoursatyApp.Data.Repositories
{
    public interface IRepository<TEnitiy> 
    {
        TEnitiy Add(TEnitiy enitiy);
        TEnitiy Update(TEnitiy enitiy);

        TEnitiy Get(int id);

        TEnitiy Delete(int id);

        IEnumerable<TEnitiy> GetAll();

    }
}
