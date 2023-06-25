using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArtWebApp.Data;
using ArtWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArtWebApp.Pages.Workshops
{
    [Authorize(Roles = "Admin, Manager")]
    public class CreateModel : GalleryNamePageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public CreateModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateGalleryDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Workshop Workshop { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyWorkshop = new Workshop();

            if (await TryUpdateModelAsync<Workshop>(
                 emptyWorkshop,
                 "workshop",   // Prefix for form value.
                 w => w.WorkshopID, w => w.WorkshopTitle, w => w.GalleryID, w => w.WorkshopDate, w => w.NumberOfStudents))
            {
                _context.Workshop.Add(emptyWorkshop);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateGalleryDropDownList(_context, emptyWorkshop.GalleryID);
            return Page();
        }
    }
}
