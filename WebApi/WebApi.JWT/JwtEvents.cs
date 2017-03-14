namespace WebApi.JWT
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http.Authentication;
    using System;
    using System.Collections.Generic;
    using Microsoft.IdentityModel.Tokens;

    public class JwtEvents : JwtBearerEvents
    {
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtEvents(TokenValidationParameters tokenValidationParameters)
        {
            _tokenValidationParameters = tokenValidationParameters;
        }

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
            //var principal = context.HttpContext.User.Identity as ClaimsPrincipal;
            //var token = context.Request.Headers["Authorization"][0].Substring(context.Options.AuthenticationScheme.Length + 1);
            //List<Exception> validationFailures = null;
            //SecurityToken validatedToken = null;
            //ClaimsPrincipal principal = null;
            //var options = context.Options;

            //foreach (var validator in options.SecurityTokenValidators)
            //{
            //    if (validator.CanReadToken(token))
            //    {
            //        try
            //        {
            //            principal = validator.ValidateToken(token, _tokenValidationParameters, out validatedToken);
            //        }
            //        catch (Exception ex)
            //        {
            //            validationFailures = validationFailures ?? new List<Exception>(1);
            //            validationFailures.Add(ex);
            //            continue;
            //        }
            //    }
            //}

            return base.TokenValidated(context);
            
        }
    }
}
