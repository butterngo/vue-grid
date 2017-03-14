namespace WebApi.Core.Identity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class User: IdentityUser
    {
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
    }
}
