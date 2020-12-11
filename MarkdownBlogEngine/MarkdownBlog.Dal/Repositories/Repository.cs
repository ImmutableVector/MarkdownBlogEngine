using Microsoft.EntityFrameworkCore;
using ProgrammingLexicon.Dal.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgrammingLexicon.Dal.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ProgrammingLexiconContext _dbContext;

        public Repository(ProgrammingLexiconContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
            => _dbContext
                .Set<TEntity>()
                .Where(predicate)
                .AsNoTracking();

        public async Task<TEntity> GetById(int id)
            => await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);

        public async Task Create(TEntity entity)
        {
            await _dbContext
                .Set<TEntity>()
                .AddAsync(entity);

            entity.DateCreated = entity.DateModified = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Update(entity);

            entity.DateModified = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext
                .Set<TEntity>()
                .Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
