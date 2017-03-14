namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class OrderDetailsService : ServiceBase<OrderDetails, OrderDetailsDto>, IOrderDetailsService
    {
        public OrderDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
