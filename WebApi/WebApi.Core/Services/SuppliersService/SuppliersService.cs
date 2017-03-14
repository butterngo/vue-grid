namespace WebApi.Core.Services
{
    using Domain;
    using WebApi.Dto;

    public class SuppliersService : ServiceBase<Suppliers, SuppliersDto>, ISuppliersService
    {
        public SuppliersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
