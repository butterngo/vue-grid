namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class ShippersService : ServiceBase<Shippers, ShippersDto>, IShippersService
    {
        public ShippersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
