using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAcces.Abstract
{
    public interface IGenericDal<T> where T : class, new()
    {
        void add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList(Expression<Func<T,bool>> filter = null);
        T Getitem(Expression<Func<T, bool>> filter);
        Task <T> Get(int id);
    }
}
