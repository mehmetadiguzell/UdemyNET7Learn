using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyNET7Learn.Utility;

namespace UdemyNET7Learn.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UdemyAppDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(UdemyAppDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
            _context.Kitaplar.Include(x => x.KitapTuru);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteWith(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public List<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }

    }
}
