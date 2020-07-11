using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtWeb.Data.Entities
{
    public class DeviceRequest
    {   
        [Key]
        public int ID { get; set; }
        
        //[Key] 
        public string DeviceKey { get; set; }

        public string HostName { get; set; }

        public Device ApprovedDevice { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}