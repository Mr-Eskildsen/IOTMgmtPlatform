using Microsoft.EntityFrameworkCore;
using IotMgmtWeb.Models;

namespace IotMgmtWeb.Data
{
    public class IotMgmtContext : DbContext
    {
        public IotMgmtContext (DbContextOptions<IotMgmtContext> options)
            : base(options)
        {
        }

        public DbSet<IotMgmtWeb.Models.Asset> Asset { get; set; }

        public DbSet<IotMgmtWeb.Models.Device> Device { get; set; }


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


        public DbSet<IotMgmtWeb.Models.Package> Package { get; set; }


    }
}
