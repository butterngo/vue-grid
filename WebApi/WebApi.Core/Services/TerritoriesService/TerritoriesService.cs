namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class TerritoriesService : ServiceBase<Territories, TerritoriesDto>, ITerritoriesService
    {
        public TerritoriesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
