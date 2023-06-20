using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.WorkshopRegisterations
{
    public class IndexModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public IndexModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WorkshopRegisteration> WorkshopRegisteration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.WorkshopRegisteration != null)
            {
                WorkshopRegisteration = await _context.WorkshopRegisteration
                .Include(w => w.Customer)
                .Include(w => w.Workshop).ToListAsync();
            }
        }
    }
}
