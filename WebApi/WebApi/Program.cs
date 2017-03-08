using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace WebApi
{
    public class Program
    {
        //Scaffold-DbContext "Server=DESKTOP-IRJHHOH;Database=NORTHWND;Integrated Security=False;User ID=sa;Password=sa;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir D:\dev\vue-grid\WebApi\WebApi.Domain
        //https://code.msdn.microsoft.com/How-to-using-Entity-1464feea
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
