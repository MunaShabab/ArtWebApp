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
    public class IndexModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public IndexModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Painting> Painting { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? TitleString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? CategoryString { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Painting != null)
            {
                var paintings = from p in _context.Painting
                                select p;
                if (!string.IsNullOrEmpty(TitleString))
                {
                    paintings = paintings.Where(s => s.PaintingID.Contains(TitleString));
                }
                if (!string.IsNullOrEmpty(CategoryString))
                {
                    paintings = paintings.Where(s => s.Category.Contains(CategoryString));
                }
                Painting = await paintings.ToListAsync();
            }
        }
    }
}
