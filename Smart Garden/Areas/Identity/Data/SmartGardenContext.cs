﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartGarden.Models;

namespace SmartGarden.Data
{
    public class SmartGardenContext : IdentityDbContext<IdentityUser>
    {
        public SmartGardenContext(DbContextOptions<SmartGardenContext> options)
            : base(options)
        {
        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<CultivationPlan> CultivationPlans { get; set; }
        public DbSet<MeasurementHistory> MeasurementHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
