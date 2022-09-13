using Core.DataAcces.Abstract;
using Core.entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAcces.Concrete
{
    public class EfGenericRepository<T, TContext> : IGenericDal<T> 
        where T : class, IEntity, new()
        where TContext :DbContext,new()
    {
      /*  private readonly TContext context;

        public EfGenericRepository( TContext _context)
        {
            this.context = _context;  bu bana daha sağlıklı gelse de using ile deniyorum
        }
      */

        public void add(T entity)
        {
            using(var context =new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {   
                
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }
        
        public async Task<T> Get(int id)
        {
            using (var context = new TContext())
            {

             return  await context.Set<T>().FindAsync(id);

               
            }
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            using( var context = new TContext())
            {
                return context.Set<T>().Where(filter).Count();
            }
        }

        public T Getitem(Expression<Func<T, bool>> filter)
        {

            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).FirstOrDefault();


            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return  filter is null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
              

             

            }
        }

        public void Update(T entity)
        {
            using(var context = new TContext())
            {

                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
        }

    
    }
}
