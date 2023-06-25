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

namespace ArtWebApp.Pages.Shows
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
        public Show Show { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            var emptyShow = new Show();

            if (await TryUpdateModelAsync<Show>(
                 emptyShow,
                 "show",   // Prefix for form value.
                 s => s.ShowID, s => s.ShowTitle, s => s.GalleryID, s => s.StartDate, s =>s.EndDate))
            {
                _context.Show.Add(emptyShow);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateGalleryDropDownList(_context, emptyShow.GalleryID);
            return Page();
        }
    }
}
