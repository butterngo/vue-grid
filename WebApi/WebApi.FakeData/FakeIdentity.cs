namespace WebApi.FakeData
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using WebApi.Common.Helpers;
    using WebApi.Core;
    using WebApi.Core.Identity;
    using WebApi.Domain;
    using WebApi.Domain.Enum;

    public class FakeIdentity
    {
        private readonly WebApiUserManager _userManager;

        private readonly IUnitOfWork _unitOfWork;

        public FakeIdentity(WebApiUserManager userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;

            _unitOfWork = unitOfWork;
        }

        public async Task CreateUserAsync()
        {
            PasswordHasher<User> userHasher = new PasswordHasher<User>();

            PasswordHasher<Client> clientHasher = new PasswordHasher<Client>();

            var client = new Client()
            {
                Name = "Butter Ngo",
                Active = true,
                RefreshTokenLifeTime = 7,
                TokenLifeTime = 20,
                AllowedGrant = OAuthGrant.SystemAdmin,
                AllowedOrigin = "*"
            };

            client.ClientId = UnitHelper.GenerateNewGuid();
            client.SecretKey= UnitHelper.GenerateNewGuid();
            client.Secret = clientHasher.HashPassword(client, client.SecretKey);
            _unitOfWork.ClientRepository.Add(client);

            var user = new User { UserName = "admin" };

            user.PasswordHash = userHasher.HashPassword(user, "admin");
            user.ClientId = client.ClientId;
            user.SecretKey = client.SecretKey;

            await _userManager.CreateAsync(user);

            await _unitOfWork.CommitAsync();
        }
    }
}
