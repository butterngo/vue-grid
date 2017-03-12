namespace WebApi.JWT
{
    using System;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.JwtBearer;

    public class JwtEvents : JwtBearerEvents
    {
        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            return base.AuthenticationFailed(context);
        }

        public override Task Challenge(JwtBearerChallengeContext context)
        {
            return base.Challenge(context);
        }

        public override Task MessageReceived(MessageReceivedContext context)
        {
            return base.MessageReceived(context);
        }

        public override Task TokenValidated(TokenValidatedContext context)
        {
            
            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;

            //claimsIdentity.AddClaim(new Claim("id_token",
            //    context.Request.Headers["Authorization"][0].Substring(context.Options.AuthenticationScheme.Length + 1)));​

            return base.TokenValidated(context);
        }
    }
}
