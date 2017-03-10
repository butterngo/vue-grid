namespace WebApi.Core.Repository
{
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryRepository: IRepository<Categories>
    {
        Task<IEnumerable<Categories>> FindAllExceptPrictureAsync(object[] parametes = null);
    }
}
