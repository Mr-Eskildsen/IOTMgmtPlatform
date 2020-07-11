using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IotMgmtWeb.Data;
using IotMgmtWeb.Models;

namespace IotMgmtWeb.Pages.Package
{
    public class DetailsModel : PageModel
    {
        private readonly IotMgmtWeb.Data.IotMgmtContext _context;

        public DetailsModel(IotMgmtWeb.Data.IotMgmtContext context)
        {
            _context = context;
        }

        public IotMgmtWeb.Models.Package Package { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Package = await _context.Package.FirstOrDefaultAsync(m => m.ID == id);

            if (Package == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
