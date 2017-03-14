namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class CustomerCustomerDemoService : ServiceBase<CustomerCustomerDemo, CustomerCustomerDemoDto>, ICustomerCustomerDemoService
    {
        public CustomerCustomerDemoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
