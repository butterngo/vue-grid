namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public interface IEmployeesService: IServiceBase<Employees, EmployeesDto>
    {
    }
}
