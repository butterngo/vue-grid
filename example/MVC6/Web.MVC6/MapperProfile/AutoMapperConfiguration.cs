namespace Web.MVC6
{
    using AutoMapper;

    public static class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new CommonMapper());
            });
        }
    }
}
