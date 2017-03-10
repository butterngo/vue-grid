namespace WebApi.Core.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> pression = null);

        TEntity FindBy(params object[] keyValues);

        Task<TEntity> FindByAsync(params object[] keyValues);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
