using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtSrv.Models
{
    public class Package
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Version { get; set; }

        public ICollection<Package2Asset> Assets { get; set; }
    }
}