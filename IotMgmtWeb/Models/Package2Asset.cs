using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IotMgmtWeb.Models
{
   
    public class Package2Asset
    {
        [Key]
        public int ID { get; set; }

        public int Order { get; set; }
        public string AssetID { get; set; }
        public Asset _Asset { get; set; }

        public string PackageID { get; set; }
        public Package _Package { get; set; }



    }
}