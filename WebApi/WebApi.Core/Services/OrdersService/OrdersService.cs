namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class OrdersService : ServiceBase<Orders, OrdersDto>, IOrdersService
    {
        public OrdersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
