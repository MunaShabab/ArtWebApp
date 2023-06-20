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
    public class DetailsModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
