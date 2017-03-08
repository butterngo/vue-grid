namespace WebApi.Core.Services
{
    using Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using WebApi.Domain.Enum;

    public interface IServiceBase<TEntity, TDto>
    {
        Task<PageResultDto<TDto>> SearchAsync(Expression<Func<TEntity, bool>> pression = null, int skip = 0, int take = 10);

        Task<PageResultDto<TDto>> SearchAsync<TOrderBy>(Expression<Func<TEntity, bool>> pression = null,
            Expression<Func<TEntity, TOrderBy>> orderBy = null, OrderType orderType = OrderType.Descending,
            int skip = 0, int take = 10);

        Task<IEnumerable<TDto>> FindAllAsync<TOrderBy>(Expression<Func<TEntity, bool>> pression = null,
            Expression<Func<TEntity, TOrderBy>> orderBy = null, OrderType orderType = OrderType.Descending);

       Task<IEnumerable<TDto>> FindAllAsync(Expression<Func<TEntity, bool>> pression = null);

        Task<TDto> FindByIdAsync(int id);

        Task<TDto> CreateAsync(TDto model);

        Task<TDto> UpdateAsync(TDto model);

        Task DeleteAsync(int id);
    }
}
