using System;
using FlareonWeb.Areas.Identity.Data;
using FlareonWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FlareonWeb.Areas.Identity.IdentityHostingStartup))]
namespace FlareonWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FlareonWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FlareonWebContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    })
                    .AddEntityFrameworkStores<FlareonWebContext>();
            });
        }
    }
}