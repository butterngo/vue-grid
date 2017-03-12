namespace WebApi.Core.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    public class WebApiRoleManager : RoleManager<Roles>, IDisposable
    {
        public WebApiRoleManager(IRoleStore<Roles> store,
            IEnumerable<IRoleValidator<Roles>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<Roles>> logger,
            IHttpContextAccessor contextAccessor) 
            : base(store, roleValidators, keyNormalizer, errors, logger, contextAccessor)
        {
        }
    }
}
