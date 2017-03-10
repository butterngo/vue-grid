namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class EmployeesService : ServiceBase<Employees, EmployeesDto>, IEmployeesService
    {
        public EmployeesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
