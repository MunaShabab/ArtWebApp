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
    public class DeleteModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public WorkshopRegisteration WorkshopRegisteration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WorkshopRegisteration == null)
            {
                return NotFound();
            }

            var workshopregisteration = await _context.WorkshopRegisteration.FirstOrDefaultAsync(m => m.WorkshopRegisterationID == id);

            if (workshopregisteration == null)
            {
                return NotFound();
            }
            else 
            {
                WorkshopRegisteration = workshopregisteration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.WorkshopRegisteration == null)
            {
                return NotFound();
            }
            var workshopregisteration = await _context.WorkshopRegisteration.FindAsync(id);

            if (workshopregisteration != null)
            {
                WorkshopRegisteration = workshopregisteration;
                _context.WorkshopRegisteration.Remove(WorkshopRegisteration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
