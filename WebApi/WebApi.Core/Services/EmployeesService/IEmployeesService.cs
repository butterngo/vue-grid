namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public interface IEmployeesService: IServiceBase<Employees, EmployeesDto>
    {
    }
}
