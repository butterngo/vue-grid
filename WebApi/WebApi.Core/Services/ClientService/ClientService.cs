namespace WebApi.Core.Services
{
    using System.Threading.Tasks;
    using WebApi.Core.Dto;
    using WebApi.Core.Identity;
    using WebApi.Domain;
    using System;
    using System.Text;

    public class ClientService : ServiceBase<Client, ClientDto>, IClientService
    {
        private readonly WebApiUserManager _userManager;

        public ClientService(IUnitOfWork unitOfWork, WebApiUserManager userManager) : base(unitOfWork)
        {
            _userManager = userManager;
        }

        public async Task<string> GenerateHeaderAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return Convert.ToBase64String(Encoding.ASCII.GetBytes(user.ClientId + ":" + user.SecretKey));
        }
    }
}
