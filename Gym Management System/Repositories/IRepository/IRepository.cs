using System.Linq.Expressions;

namespace Gym_Management_System.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T Entity);
        void Delete(T Entity);
        T GetById(Expression<Func<T, bool>> Condition);
        T Update(Expression<Func<T, bool>> Condition);

    }
}
