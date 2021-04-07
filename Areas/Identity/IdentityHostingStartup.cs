using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilentAuction.Areas.Identity.Data;
using SilentAuction.Data;

[assembly: HostingStartup(typeof(SilentAuction.Areas.Identity.IdentityHostingStartup))]
namespace SilentAuction.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SilentAuctionIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("SilentAuctionIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SilentAuctionIdentityDbContext>();
            });
        }
    }
}