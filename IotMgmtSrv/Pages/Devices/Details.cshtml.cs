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
    public class DetailsModel : PageModel
    {
        private readonly IotMgmtSrv.Data.IotMgmtSrvContext _context;

        public DetailsModel(IotMgmtSrv.Data.IotMgmtSrvContext context)
        {
            _context = context;
        }

        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device.FirstOrDefaultAsync(m => m.ID == id);

            if (Device == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
