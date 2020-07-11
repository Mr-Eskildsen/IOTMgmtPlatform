using System.Collections.Generic;
using System.Linq;

using IotMgmtWeb.Data;
using IotMgmtWeb.Data.Entities;
using IotMgmtWeb.Services;
using IotMgmtWeb.Tests.Controller;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;

//using System.Linq.Enumerable.Count;
using Xunit;

namespace IotMgmtWeb.Tests
{
    public class DeviceRequestUnitTests
    {

        private Mock<IotMgmtContext> _CreateDbContext(int seedCount)
        {

            var options = new DbContextOptionsBuilder<IotMgmtContext>()
                        .UseInMemoryDatabase(databaseName: "IotMgmtDatabase")
                        .Options;
            var context = new Mock<IotMgmtContext>(options);

            var controller = new DeviceControllerTest(context.Object);

            var requests = controller.GetFakeDeviceRequests(seedCount).AsQueryable();
            
            var dbSet = new Mock<DbSet<DeviceRequest>>();
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.Provider).Returns(requests.Provider);
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.Expression).Returns(requests.Expression);
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.ElementType).Returns(requests.ElementType);
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.GetEnumerator()).Returns(requests.GetEnumerator());
            context.Setup(c => c.DeviceRequest).Returns(dbSet.Object);
            /*
            context.Setup(c => c.DeviceRequest).Returns(dbSet.Object);
            */
//            var service = new Mock<IDeviceRequestService>();
//            service.Setup(x => x.AllRequests()).Returns(requests);
            return context;
        }




        private IotMgmtContext CreateDbContext(int seedCount)
        {

            var options = new DbContextOptionsBuilder<IotMgmtContext>()
                        .UseInMemoryDatabase(databaseName: "IotMgmtDatabase")
                        .Options;
            var context = new IotMgmtContext(options);
            
            var controller = new DeviceControllerTest(context);

            var requests = controller.GetFakeDeviceRequests(seedCount).AsQueryable();
            foreach (DeviceRequest req in requests)
            {
                context.DeviceRequest.Add(req);
            }
            context.SaveChanges();
            /*
            var dbSet = new Mock<DbSet<DeviceRequest>>();
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.Provider).Returns(requests.Provider);
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.Expression).Returns(requests.Expression);
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.ElementType).Returns(requests.ElementType);
            dbSet.As<IQueryable<DeviceRequest>>().Setup(m => m.GetEnumerator()).Returns(requests.GetEnumerator());
            context.Setup(c => c.DeviceRequest).Returns(dbSet.Object);
            */
            /*
            context.Setup(c => c.DeviceRequest).Returns(dbSet.Object);
            */
            //            var service = new Mock<IDeviceRequestService>();
            //            service.Setup(x => x.AllRequests()).Returns(requests);
            return context;
        }

#if __SAMPLE
        //[Fact]
        public async void RequestWhitelist()
        {
            /*
            var options = new DbContextOptionsBuilder<IotMgmtContext>()
                        .UseInMemoryDatabase(databaseName: "IotMgmtDatabase")
                        .Options;
            
            var dbContext = new Mock<IotMgmtContext>(options);

            var ctrlTest = new DeviceControllerTest(dbContext.Object);

            var service = new Mock<IDeviceRequestService>();
            var request = ctrlTest.GetFakeDeviceRequest();
            service.Setup(x => x.AllRequests()).Returns(request);
            */
            var dbContext = CreateDbContext(30);
            var ctrlTest = new DeviceControllerTest(dbContext);

            var results = await ctrlTest.GetRequests();

            Assert.Equal(30, results.Value.Count());
            /*
            //var requests = ctrlTest.GetFakeDeviceRequest();


            await ctrlTest.RequestAccess("123456");
            // Act
            var results = await ctrlTest.GetRequests();

            IEnumerable<DeviceRequest> myresults = results.Value;

            // Assert
            Assert.Equal(1, myresults.Count());
            // arrange
            //var service = new Mock<IDeviceRequestService>();

*/
            /*

            //service.Setup(x => x.AllPersons()).Returns(persons);

            var controller = new DeviceControllerTest(service.Object);
            var requests = controller.GetFakeData();
            requests.
            // Act
            //var results = controller.Get ();

            //var count = results.Count();

            // Assert
            Assert.Equal(count, 26);
            */

        }
#endif //__SAMPLE


        [Fact]
        public async void DeviceWhitelisting()
        {
            string strKey1 = "12345678";
            string strKey2 = "12345679";

            IotMgmtContext dbContext = CreateDbContext(0);
            DeviceControllerTest controller = new DeviceControllerTest(dbContext);

            var results = await controller.GetRequests();
            
            //Initially we Don't expect any values in the database
            Assert.True(0 == results.Value.Count(), "The was not empty when starting the test");

            await controller.RequestAccess(strKey1);
            results = await controller.GetRequests();

            //Verify that request was saved
            Assert.True(1 == results.Value.Count(), "Request for whitelisting failed");

            
            await controller.RequestAccess(strKey1);
            results = await controller.GetRequests();

            //Verify that same request was not saved
            Assert.True(1 == results.Value.Count(), "");


            await controller.RequestAccess(strKey2);
            results = await controller.GetRequests();

            //Verify that same request was not saved
            Assert.True(2 == results.Value.Count(), "Failed to save second whitelist request");


            //TODO:: Approve


            //TODO:: Same request again


        }
    }
}
