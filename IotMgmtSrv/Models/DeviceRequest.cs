﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtSrv.Models
{
    public class DeviceRequest
    {
        public int Id { get; set; }
        public string DeviceForeignKey { get; set; }

        public string Host { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}