namespace WebApi.Common.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public static class UnitHelper
    {
        public static string GenerateNewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static TResult JsonToDto<TResult>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(json);
        }

    }
}
