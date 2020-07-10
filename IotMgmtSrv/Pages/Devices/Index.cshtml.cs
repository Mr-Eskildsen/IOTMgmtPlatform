using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IotMgmtSrv.Data;
using IotMgmtSrv.Models;

namespace IotMgmtSrv.Pages.Devices
{
    public class IndexModel : PageModel
    {
        private readonly IotMgmtSrv.Data.IotMgmtSrvContext _context;

        public IndexModel(IotMgmtSrv.Data.IotMgmtSrvContext context)
        {
            _context = context;
        }

        public IList<Device> Device { get;set; }

        public async Task OnGetAsync()
        {
            Device = await _context.Device.ToListAsync();
        }
    }
}
