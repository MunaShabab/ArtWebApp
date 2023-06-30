using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArtWebApp.Data;
using ArtWebApp.Models;
using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Authorization;


namespace ArtWebApp.Pages.ShowPaintings
{
    [Authorize(Roles = "Admin, Manager")]
    public class CreateModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public CreateModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PaintingID"] = new SelectList(_context.Painting, "PaintingID", "PaintingID");
        ViewData["ShowID"] = new SelectList(_context.Show, "ShowID", "ShowTitle");
            return Page();
        }

        [BindProperty]
        public ShowPainting ShowPainting { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyShowPainting = new ShowPainting();

            if (await TryUpdateModelAsync<ShowPainting>(
                 emptyShowPainting,
                 "showPainting",   // Prefix for form value.
                s => s.ShowPaintingID, s => s.PaintingID, s => s.ShowID, s => s.Award))
            {  _context.ShowPainting.Add(emptyShowPainting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }
    }
}
