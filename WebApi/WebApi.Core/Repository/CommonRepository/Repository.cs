namespace WebApi.Core.Repository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;

    public abstract class Repository<TEntity, TContext>: IRepository<TEntity>
        where TEntity : class
        where TContext : NORTHWNDContext
    {
        protected readonly TContext _context;
        
        public Repository(TContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> pression = null)
        {
            IQueryable<TEntity> query = null;

            if (pression == null) query = _context.Set<TEntity>();

            else query = _context.Set<TEntity>().Where(pression);
            
            return query;
        }

        public virtual TEntity FindBy(params object[] keyValues)
        {
            return _context.Set<TEntity>().Find(keyValues);
        }

        public virtual async Task<TEntity> FindByAsync(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

    }
}
