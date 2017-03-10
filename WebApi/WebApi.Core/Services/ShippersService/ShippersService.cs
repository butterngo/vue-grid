namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Core.Dto;

    public class ShippersService : ServiceBase<Shippers, ShippersDto>, IShippersService
    {
        public ShippersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
