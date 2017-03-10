namespace WebApi.Core.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class CategoryRepository : Repository<Categories, NORTHWNDContext>, ICategoryRepository
    {
        private const string QUERY = @"Select CategoryId, CategoryName, Description , NULL as Picture from Categories";

        public CategoryRepository(NORTHWNDContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Categories>> FindAllExceptPrictureAsync(object[] parametes = null)
        {
            if (parametes == null)
            {
                return await _context.Categories.FromSql(QUERY).ToArrayAsync();
            }
            else
            {
                return await _context.Categories.FromSql(QUERY, parametes).ToArrayAsync();
            }
        }
    }
}
