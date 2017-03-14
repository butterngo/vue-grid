namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class OrdersService : ServiceBase<Orders, OrdersDto>, IOrdersService
    {
        public OrdersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
