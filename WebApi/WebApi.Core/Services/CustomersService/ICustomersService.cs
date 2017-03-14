namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public interface ICustomersService: IServiceBase<Customers, CustomersDto>
    {
    }
}
