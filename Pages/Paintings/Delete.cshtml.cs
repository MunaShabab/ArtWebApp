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

namespace ArtWebApp.Pages.Paintings
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Painting Painting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Painting == null)
            {
                return NotFound();
            }

            var painting = await _context.Painting.FirstOrDefaultAsync(m => m.PaintingID == id);

            if (painting == null)
            {
                return NotFound();
            }
            else 
            {
                Painting = painting;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Painting == null)
            {
                return NotFound();
            }
            var painting = await _context.Painting.FindAsync(id);

            if (painting != null)
            {
                Painting = painting;
                _context.Painting.Remove(Painting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
