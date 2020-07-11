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
    public class IndexModel : PageModel
    {
        private readonly IotMgmtContext _context;

        public IndexModel(IotMgmtContext context)
        {
            _context = context;
        }

        public IList<IotMgmtWeb.Models.Package> Package { get;set; }

        public async Task OnGetAsync()
        {
            Package = await _context.Package.ToListAsync();
        }
    }
}
