using IotMgmtWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtWeb.Data.Entities
{
    public class Device
    {
        public int ID { get; set; }
        //public string DeviceForeignKey { get; set; }

        public string Name { get; set; }

        public int DeviceRequestID { get; set; }
        public DeviceRequest deviceRequest;
        
    }
}