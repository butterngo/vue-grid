namespace WebApi.Core.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using WebApi.Common.Factories;
    using WebApi.Domain;

    public class WebApiUserManager : UserManager<User>, IDisposable
    {
        public WebApiUserManager(IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services, ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        public static IdentityOptions CreateOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;

            options.User.RequireUniqueEmail = false;

            return options;
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType)
        {
            IList<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id, null, ClaimsIdentity.DefaultIssuer, "Provider"));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName, null, ClaimsIdentity.DefaultIssuer, "Provider"));

            var claimsIdentity = new ClaimsIdentity(claims, authenticationType);

            return await Task.FromResult(claimsIdentity);
        }

        public async Task<User> FindAsync(string username, string password)
        {
            var user = await this.FindByNameAsync(username);

            var isPw = await this.CheckPasswordAsync(user, password);

            return (isPw ? user : null);
        }
    }
}
