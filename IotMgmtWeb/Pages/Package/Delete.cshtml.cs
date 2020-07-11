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
    public class DeleteModel : PageModel
    {
        private readonly IotMgmtWeb.Data.IotMgmtContext _context;

        public DeleteModel(IotMgmtWeb.Data.IotMgmtContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Package = await _context.Package.FindAsync(id);

            if (Package != null)
            {
                _context.Package.Remove(Package);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
