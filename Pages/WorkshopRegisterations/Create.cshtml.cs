using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.WorkshopRegisterations
{
    public class CreateModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public CreateModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "LastName");
        ViewData["WorkshopID"] = new SelectList(_context.Set<Workshop>(), "WorkshopID", "WorkshopTitle");
            return Page();
        }

        [BindProperty]
        public WorkshopRegisteration WorkshopRegisteration { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.WorkshopRegisteration == null || WorkshopRegisteration == null)
            {
                return Page();
            }

            _context.WorkshopRegisteration.Add(WorkshopRegisteration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
