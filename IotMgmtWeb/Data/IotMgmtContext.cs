using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

using IotMgmtWeb.Models;
using IotMgmtWeb.Data.Entities;

namespace IotMgmtWeb.Data
{

    public interface IIotMgmtContext
    {

        public DbSet<Asset> Asset { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<DeviceRequest> DeviceRequest { get; set; }
        public DbSet<Package> Package { get; set; }

    }

    public class IotMgmtContext : DbContext, IIotMgmtContext
    {
        public IotMgmtContext (DbContextOptions<IotMgmtContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Asset { get; set; }

        public DbSet<Device> Device { get; set; }
        public DbSet<DeviceRequest> DeviceRequest { get; set; }

        public DbSet<Package> Package { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Package2Asset>().HasNoKey();
            modelBuilder.Entity<Package2Asset>(relationship =>
            {
                relationship.HasOne(r => r._Asset ).WithMany(u => u.Packages);
            });
            modelBuilder.Entity<Package2Asset>(relationship =>
            {
                relationship.HasOne(r => r._Package).WithMany(u => u.Assets);
            });
        }


    }
}
