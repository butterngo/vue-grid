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

    }
}
