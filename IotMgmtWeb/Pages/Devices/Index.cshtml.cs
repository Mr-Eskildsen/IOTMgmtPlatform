using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IotMgmtWeb.Data;
using IotMgmtWeb.Models;

namespace IotMgmtWeb.Pages.Devices
{
    public class IndexModel : PageModel
    {
        private readonly IotMgmtWeb.Data.IotMgmtContext _context;

        public IndexModel(IotMgmtWeb.Data.IotMgmtContext context)
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
