namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class RegionService : ServiceBase<Region, RegionDto>, IRegionService
    {
        public RegionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
