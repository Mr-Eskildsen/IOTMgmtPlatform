using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtSrv.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string DeviceForeignKey { get; set; }

        public string Name { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}