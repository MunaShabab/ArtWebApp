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

namespace ArtWebApp.Pages.ShowPaintings
{
    public class EditModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public EditModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShowPainting ShowPainting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShowPainting == null)
            {
                return NotFound();
            }

            var showpainting =  await _context.ShowPainting.FirstOrDefaultAsync(m => m.ShowPaintingID == id);
            if (showpainting == null)
            {
                return NotFound();
            }
            ShowPainting = showpainting;
           ViewData["PaintingID"] = new SelectList(_context.Set<Painting>(), "PaintingID", "PaintingID");
           ViewData["ShowID"] = new SelectList(_context.Show, "ShowID", "ShowTitle");
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

            _context.Attach(ShowPainting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowPaintingExists(ShowPainting.ShowPaintingID))
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

        private bool ShowPaintingExists(int id)
        {
          return (_context.ShowPainting?.Any(e => e.ShowPaintingID == id)).GetValueOrDefault();
        }
    }
}
