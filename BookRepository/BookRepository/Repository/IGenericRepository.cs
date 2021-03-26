using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookRepository.Repository
{
    public interface IGenericRepository<T>where T:class
    {
        IEnumerable<T> GetAll();
        void Insert(T Obj);
        void Update(T entity);
        void Delete(object id);
        IEnumerable<T> GetAllList(Expression<Func<T, bool>> whereCondition);
    }
}
