using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IotMgmtSrv.Models
{
   
    public class Package2Asset
    {
        [Key]
        public int ID { get; set; }

        public int Order { get; set; }
        public string AssetId { get; set; }
        public Asset _Asset { get; set; }

        public string PackageId { get; set; }
        public Package _Package { get; set; }



    }
}