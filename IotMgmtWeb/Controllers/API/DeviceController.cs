using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IotMgmtWeb.Data;
using IotMgmtWeb.Models;
using IotMgmtWeb.Data.Entities;

namespace IotMgmtWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        protected readonly IotMgmtContext _context;

        public DeviceController(IotMgmtContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        [Route("api/[controller]/Requests")]
        public async Task<ActionResult<IEnumerable<DeviceRequest>>> GetRequests()
        {
            return await _context.DeviceRequest.ToListAsync();
        }



        // PUT: api/Devices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /*
        [Route("api/DoStuff/{reqParam}")]
        [Route("api/DoStuff/{reqParam}/{optParam1:alpha?}/{optParam2:datetime?}")]
        public string Get(string reqParam, string optParam1 = "", string optParam2 = "")
            */
        /*
        //[HttpPut("{deviceKey}/{hostName}")]
        [HttpPut]
        //[Route("api/[controller]/{deviceKey}")]
        [Route("api/[controller]/{deviceKey}/{hostName}")]
        */
        [HttpPut]//("{deviceKey}/{hostName}")]
        [Route("api/[controller]/Requests/{deviceKey}/{hostName}")]
        public async Task<IActionResult> RequestAccess(String deviceKey, String hostName)
        {
            try
            { 

                if (_context.DeviceRequest.Any(dr => dr.DeviceKey == deviceKey)) return NoContent();
                DeviceRequest request = new DeviceRequest();
                request.DeviceKey = deviceKey;
                request.HostName = hostName;
                request.ApprovedDevice = null;
                
                _context.DeviceRequest.Add(request);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /*
                if (!DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                */
                throw;
            }

            return NoContent();
        }


        [HttpPut]
        [Route("api/[controller]/Request/{deviceKey}")]
        public async Task<IActionResult> RequestAccess(String deviceKey)
        {
            return await RequestAccess(deviceKey, String.Empty);
        }

        /*
    public async Task<IActionResult> RequestWhitelist(String deviceKey, String hostName = "")
    {

        if (id != device.ID)
        {
            return BadRequest();
        }

        _context.Entry(device).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DeviceExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
        */

        /*
        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevice()
        {
            return await _context.Device.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Device.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.ID)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Devices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.Device.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.ID }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Device>> DeleteDevice(int id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Device.Remove(device);
            await _context.SaveChangesAsync();

            return device;
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.ID == id);
        }
        */
    }
}
