﻿namespace WebApi.JWT
{
    using System;
    using Microsoft.IdentityModel.Tokens;

    public class TokenProviderOptions
    {

        public string Path { get; set; } = "/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
