namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class CustomersService : ServiceBase<Customers, CustomersDto>, ICustomersService
    {
        public CustomersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
