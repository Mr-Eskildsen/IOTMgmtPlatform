using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtWeb.Models
{
    public class DeviceRequest
    {
        public int ID { get; set; }
        public string DeviceForeignKey { get; set; }

        public string Host { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}