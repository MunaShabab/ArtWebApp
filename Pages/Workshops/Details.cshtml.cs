using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.Workshops
{
    public class DetailsModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
