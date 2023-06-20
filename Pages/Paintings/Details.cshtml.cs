using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.Paintings
{
    public class DetailsModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
