namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class CustomersService : ServiceBase<Customers, CustomersDto>, ICustomersService
    {
        public CustomersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
