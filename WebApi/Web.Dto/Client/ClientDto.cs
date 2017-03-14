﻿namespace WebApi.Dto
{
    using WebApi.Dto.Enum;

    public class ClientDto
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string SecretKey { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public int TokenLifeTime { get; set; }
        public OAuthGrant AllowedGrant { get; set; }
        public string AllowedOrigin { get; set; }
    }
}
