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
    }
}
