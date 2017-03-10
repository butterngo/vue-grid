namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public interface IOrdersService: IServiceBase<Orders, OrdersDto>
    {
    }
}
