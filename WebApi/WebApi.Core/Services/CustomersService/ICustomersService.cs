namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public interface ICustomersService: IServiceBase<Customers, CustomersDto>
    {
    }
}
