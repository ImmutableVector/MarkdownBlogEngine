using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgrammingLexicon.Dal.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
