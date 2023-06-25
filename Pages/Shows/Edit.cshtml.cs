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

namespace ArtWebApp.Pages.Shows
{
    [Authorize(Roles = "Admin, Manager")]
    public class EditModel : GalleryNamePageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public EditModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Show Show { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Show = await _context.Show
                 .FirstOrDefaultAsync(m => m.ShowID == id);

            if (Show == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateGalleryDropDownList(_context, Show.ShowID);
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showToUpdate = await _context.Show.FindAsync(id);

            if (showToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Show>(
                 showToUpdate,
                 "show",   // Prefix for form value.
                   s => s.ShowID, s => s.ShowTitle, s => s.GalleryID, s => s.StartDate, s => s.EndDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateGalleryDropDownList(_context, showToUpdate.GalleryID);
            return Page();
        }

        private bool ShowExists(int id)
        {
          return (_context.Show?.Any(e => e.ShowID == id)).GetValueOrDefault();
        }
    }
}
