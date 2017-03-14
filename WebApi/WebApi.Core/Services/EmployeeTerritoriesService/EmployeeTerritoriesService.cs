namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class EmployeeTerritoriesService : ServiceBase<EmployeeTerritories, EmployeeTerritoriesDto>, IEmployeeTerritoriesService
    {
        public EmployeeTerritoriesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
