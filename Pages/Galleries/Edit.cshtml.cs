using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArtWebApp.Pages.Galleries
{
    [Authorize(Roles ="Manager")]
    public class EditModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public EditModel(ArtWebApp.Data.ApplicationDbContext context)
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

            var gallery =  await _context.Gallery.FirstOrDefaultAsync(m => m.GalleryID == id);
            if (gallery == null)
            {
                return NotFound();
            }
            Gallery = gallery;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Gallery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(Gallery.GalleryID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GalleryExists(int id)
        {
          return (_context.Gallery?.Any(e => e.GalleryID == id)).GetValueOrDefault();
        }
    }
}
