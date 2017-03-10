namespace WebApi.Core.Repository
{
    public sealed class GenericRepository<TEntity, TContext> : Repository<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class
        where TContext : NORTHWNDContext
    {
        public GenericRepository(TContext context) : base(context) { }

    }
}
