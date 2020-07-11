using GenFu;
using IotMgmtWeb.Controllers.API;
using IotMgmtWeb.Data;
using IotMgmtWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IotMgmtWeb.Tests.Controller
{
    class DeviceControllerTest : DeviceController
    {
        public DeviceControllerTest(IotMgmtContext context)
            : base(context)
        {
        }
        public DeviceRequest GetFakeDeviceRequest(String deviceKey)
        {
            DeviceRequest deviceRequest = A.New<DeviceRequest>();
            
            deviceRequest.DeviceKey = deviceKey;

            return deviceRequest;


        }

        //public IEnumerable<DeviceRequest> GetFakeDeviceRequest()
        public IEnumerable<DeviceRequest> GetFakeDeviceRequests(int count)
        {
            var i = 1;
            var requests = A.ListOf<DeviceRequest>(count);
            requests.ForEach(x => x.ID = i++);
            return requests.Select(_ => _);
            

        }
    }
}
