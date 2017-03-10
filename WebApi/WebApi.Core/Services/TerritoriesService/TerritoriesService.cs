namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class TerritoriesService : ServiceBase<Territories, TerritoriesDto>, ITerritoriesService
    {
        public TerritoriesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
