namespace WebApi.Core.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System;

    public class WebApiRoleStore : RoleStore<Roles>, IRoleStore<Roles>, IDisposable
    {
        public WebApiRoleStore(NORTHWNDContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
