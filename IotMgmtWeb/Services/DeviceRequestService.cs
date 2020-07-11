using IotMgmtWeb.Data;
using IotMgmtWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotMgmtWeb.Services
{
    public class DeviceRequestService : IDeviceRequestService
    {
        private readonly IotMgmtContext _dbContext;
        public DeviceRequestService(IotMgmtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DeviceRequest> AllRequests()
        {
            return _dbContext.DeviceRequest
                        .ToList();
            //.OrderBy(x => x.DateOfBirth)
        }

            public DeviceRequest FindRequest(String deviceKey)
        {
            return _dbContext.DeviceRequest
                .FirstOrDefault(x => x.DeviceKey == deviceKey);
        }
    }

 
    public interface IDeviceRequestService
    {
        IEnumerable<DeviceRequest> AllRequests();
        DeviceRequest FindRequest(String deviceKey);
    }
}
