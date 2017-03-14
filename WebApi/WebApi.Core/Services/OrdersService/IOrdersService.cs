namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public interface IOrdersService: IServiceBase<Orders, OrdersDto>
    {
    }
}
