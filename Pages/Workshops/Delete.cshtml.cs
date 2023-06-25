using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArtWebApp.Pages.Workshops
{
    [Authorize(Roles = "Admin, Manager")]
    public class DeleteModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Workshop Workshop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workshop == null)
            {
                return NotFound();
            }

            var workshop = await _context.Workshop.FirstOrDefaultAsync(m => m.WorkshopID == id);

            if (workshop == null)
            {
                return NotFound();
            }
            else 
            {
                Workshop = workshop;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Workshop == null)
            {
                return NotFound();
            }
            var workshop = await _context.Workshop.FindAsync(id);

            if (workshop != null)
            {
                Workshop = workshop;
                _context.Workshop.Remove(Workshop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
