using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelAppServer.Data.Mappers;

namespace TravelAppServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TravelPlanConfiguration());
            modelBuilder.ApplyConfiguration(new TravelItemConfiguration());
            modelBuilder.ApplyConfiguration(new TravelTaskConfiguration());
            modelBuilder.ApplyConfiguration(new TravelRouteConfiguration());
            modelBuilder.ApplyConfiguration(new TravelLocationConfiguration());
        }
    }
}
