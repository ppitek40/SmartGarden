﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartGarden.Data;

[assembly: HostingStartup(typeof(SmartGarden.Areas.Identity.IdentityHostingStartup))]
namespace SmartGarden.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SmartGardenContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("Smart_GardenContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SmartGardenContext>();
            });
        }
    }
}