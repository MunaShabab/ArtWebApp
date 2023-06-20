using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.Galleries
{
    public class DeleteModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Gallery Gallery { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gallery == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery.FirstOrDefaultAsync(m => m.GalleryID == id);

            if (gallery == null)
            {
                return NotFound();
            }
            else 
            {
                Gallery = gallery;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Gallery == null)
            {
                return NotFound();
            }
            var gallery = await _context.Gallery.FindAsync(id);

            if (gallery != null)
            {
                Gallery = gallery;
                _context.Gallery.Remove(Gallery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
