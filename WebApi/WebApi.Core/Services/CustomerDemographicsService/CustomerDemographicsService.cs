namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class CustomerDemographicsService : ServiceBase<CustomerDemographics, CustomerDemographicsDto>, ICustomerDemographicsService
    {
        public CustomerDemographicsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
