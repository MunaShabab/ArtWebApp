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

namespace ArtWebApp.Pages.WorkshopRegisterations
{
    [Authorize(Roles = "Admin, Manager")]
    public class EditModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public EditModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkshopRegisteration WorkshopRegisteration { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WorkshopRegisteration == null)
            {
                return NotFound();
            }

            var workshopregisteration =  await _context.WorkshopRegisteration.FirstOrDefaultAsync(m => m.WorkshopRegisterationID == id);
            if (workshopregisteration == null)
            {
                return NotFound();
            }
            WorkshopRegisteration = workshopregisteration;
           ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "City");
           ViewData["WorkshopID"] = new SelectList(_context.Set<Workshop>(), "WorkshopID", "WorkshopTitle");
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

            _context.Attach(WorkshopRegisteration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopRegisterationExists(WorkshopRegisteration.WorkshopRegisterationID))
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

        private bool WorkshopRegisterationExists(int id)
        {
          return (_context.WorkshopRegisteration?.Any(e => e.WorkshopRegisterationID == id)).GetValueOrDefault();
        }
    }
}
