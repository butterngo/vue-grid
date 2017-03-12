namespace WebApi.Core.Identity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System.Collections.Generic;

    public class Roles : IdentityRole
    {
        public static readonly string Administrator = "Administrator";
        public static IEnumerable<string> FindAll()
        {
            yield return Roles.Administrator;
        }
    }
}
