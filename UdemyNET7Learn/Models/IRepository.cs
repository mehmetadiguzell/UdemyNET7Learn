using System.Linq.Expressions;

namespace UdemyNET7Learn.Models
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProps = null);
        void Delete(T entity);
        void Add(T entity);
        void DeleteWith(IEnumerable<T> entities);
    }
}
