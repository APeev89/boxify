using boxify.Data.ModelsDb;
using System.Linq;
using System.Linq.Expressions;

namespace boxify.Data.Common
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;
        int SaveChanges();
    }
}
