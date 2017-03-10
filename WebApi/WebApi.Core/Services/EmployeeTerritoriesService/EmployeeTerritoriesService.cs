namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class EmployeeTerritoriesService : ServiceBase<EmployeeTerritories, EmployeeTerritoriesDto>, IEmployeeTerritoriesService
    {
        public EmployeeTerritoriesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
