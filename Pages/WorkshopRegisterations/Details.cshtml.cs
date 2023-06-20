using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.WorkshopRegisterations
{
    public class DetailsModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public WorkshopRegisteration WorkshopRegisteration { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WorkshopRegisteration == null)
            {
                return NotFound();
            }

            var workshopregisteration = await _context.WorkshopRegisteration.FirstOrDefaultAsync(m => m.WorkshopRegisterationID == id);
            if (workshopregisteration == null)
            {
                return NotFound();
            }
            else 
            {
                WorkshopRegisteration = workshopregisteration;
            }
            return Page();
        }
    }
}
