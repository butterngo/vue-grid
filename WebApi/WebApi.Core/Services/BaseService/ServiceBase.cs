namespace WebApi.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using System.Linq;
    using Dto;
    using Repository;
    using Microsoft.EntityFrameworkCore;
    using WebApi.Domain.Enum;

    public abstract class ServiceBase<TEntity, TDto> : IServiceBase<TEntity,TDto>
        where TEntity : class
        where TDto : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected IRepository<TEntity> _repository;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public virtual async Task<TDto> CreateAsync(TDto model)
        {
            var entity = DtoToEntity(model);

            _repository.Add(entity);

            await _unitOfWork.CommitAsync();

            return EntityToDto(entity);
        }

        public virtual async Task<TDto> UpdateAsync(TDto model)
        {
            var entity = DtoToEntity(model);

            _repository.Update(entity);

            await _unitOfWork.CommitAsync();

            return EntityToDto(entity);

        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.FindByAsync(id);

            if (entity == null) throw new Exception("Not found entity object with id: " + id);

            _repository.Delete(entity);

            await _unitOfWork.CommitAsync();
        }

        public virtual async Task<IEnumerable<TDto>> FindAllAsync(Expression<Func<TEntity, bool>> pression = null)
        {
            return EntityToDto(await FindAll(pression).ToListAsync());
        }

        public virtual async Task<IEnumerable<TDto>> FindAllAsync<TOrderBy>(Expression<Func<TEntity, bool>> pression = null,
            Expression<Func<TEntity, TOrderBy>> orderBy = null, OrderType orderType = OrderType.Descending)
        {
            var query = FindAll(pression);

            //query = BuildOrderBy(query, orderBy, orderType);

            return EntityToDto(await query.ToListAsync());
        }

        public virtual async Task<TDto> FindByIdAsync(int id)
        {
            return EntityToDto(await _repository.FindByAsync(id));
        }

        public virtual async Task<PageResultDto<TDto>> SearchAsync(Expression<Func<TEntity, bool>> pression = null,
            int skip = 0, int take = 10)
        {
            var query = FindAll(pression);

            IEnumerable<TEntity> entities = await query.Skip((skip * take)).Take(take).ToListAsync();

            return new PageResultDto<TDto>(await query.CountAsync(), GetTotalPage(await query.CountAsync(), take), EntityToDto(entities));
        }

        public virtual async Task<PageResultDto<TDto>> SearchAsync<TOrderBy>(Expression<Func<TEntity, bool>> pression = null,
            Expression<Func<TEntity, TOrderBy>> orderBy = null, OrderType orderType = OrderType.Descending,
            int skip = 0, int take = 10)
        {
            var query = FindAll(pression);

            //query = BuildOrderBy(query, orderBy, orderType);

            IEnumerable<TEntity> entities = await query.Skip(skip).Take(take).ToListAsync();

            return new PageResultDto<TDto>(await query.CountAsync(), GetTotalPage(await query.CountAsync(), take), EntityToDto(entities));
        }
        
        //protected IQueryable<TEntity> BuildOrderBy<TOrderBy>(IQueryable<TEntity> query,
        //  Expression<Func<TEntity, TOrderBy>> orderBy,
        //  OrderType orderType = OrderType.Descending)
        //{
        //    if (orderBy != null)
        //    {
        //        query = (orderType == OrderType.Ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy));
        //    }
        //    else
        //    {
        //        query = query.OrderByDescending(x => x.Id);
        //    }

        //    return query;
        //}

        protected IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> pression)
        {
            IQueryable<TEntity> query = _repository.FindAll(pression);
            
            return query;
        }
        
        protected TDto EntityToDto(TEntity entity)
        {
            return Mapper.Map<TDto>(entity);
        }

        protected TEntity DtoToEntity(TDto dto)
        {
            return Mapper.Map<TEntity>(dto);
        }

        protected TEntity DtoToEntity(TDto dto, TEntity entity)
        {
            return Mapper.Map(dto, entity);
        }

        protected IEnumerable<TDto> EntityToDto(IEnumerable<TEntity> entities)
        {
            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        protected IEnumerable<TEntity> DtoToEntity(IEnumerable<TDto> dto)
        {
            return Mapper.Map<IEnumerable<TEntity>>(dto);
        }

        protected int GetTotalPage(int totalRecord, int take)
        {
            if (take > 0)
            {
                return (int)Math.Ceiling((double)((double)totalRecord / (double)take));
            }
            throw new Exception("The take parameter require greater than zero.");
        }
    }
}
