namespace WebApi.Core.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class WebApiUserStore : UserStore<User, Roles, NORTHWNDContext, string>
    {
        public WebApiUserStore(NORTHWNDContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
