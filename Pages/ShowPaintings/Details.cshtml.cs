using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.ShowPaintings
{
    public class DetailsModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ShowPainting ShowPainting { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShowPainting == null)
            {
                return NotFound();
            }

            var showpainting = await _context.ShowPainting.FirstOrDefaultAsync(m => m.ShowPaintingID == id);
            if (showpainting == null)
            {
                return NotFound();
            }
            else 
            {
                ShowPainting = showpainting;
            }
            return Page();
        }
    }
}
