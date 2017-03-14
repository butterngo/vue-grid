namespace WebApi.Domain
{
    using System.ComponentModel.DataAnnotations;
    using WebApi.Domain.Enum;

    public class Client
    {
        [Key]
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
