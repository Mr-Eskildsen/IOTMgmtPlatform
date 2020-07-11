using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IotMgmtSrv.Models;

namespace IotMgmtSrv.Data
{
    public class IotMgmtSrvContext : DbContext
    {
        public IotMgmtSrvContext (DbContextOptions<IotMgmtSrvContext> options)
            : base(options)
        {
        }

        public DbSet<IotMgmtSrv.Models.Asset> Asset { get; set; }

        public DbSet<IotMgmtSrv.Models.Device> Device { get; set; }


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
