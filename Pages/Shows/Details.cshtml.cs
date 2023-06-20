using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.Shows
{
    public class DetailsModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Show Show { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Show == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FirstOrDefaultAsync(m => m.ShowID == id);
            if (show == null)
            {
                return NotFound();
            }
            else 
            {
                Show = show;
            }
            return Page();
        }
    }
}
