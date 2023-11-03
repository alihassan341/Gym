using Gym_Management_System.Data;
using Gym_Management_System.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace Gym_Management_System.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context context;
        internal DbSet<T> dbset;
        public Repository(Context context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }
        public void Add(T Entity)
        {
            dbset.Add(Entity);
        }
        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> Query =dbset.AsQueryable();
            return Query.ToList();            
        }
        public T GetById(Expression<Func<T, bool>> Condition)
        {
            //IQueryable = dbset.Add(T)
            throw new NotImplementedException();
        }
        public T Update(Expression<Func<T, bool>> Condition)
        {
            throw new NotImplementedException();
        }
    }
}
