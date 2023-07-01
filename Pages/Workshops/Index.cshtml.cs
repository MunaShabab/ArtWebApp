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
    public class IndexModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public IndexModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Workshop> Workshop { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {

            if (_context.Workshop != null)
            {
                var workshops = from w in _context.Workshop
                                select w;
                var galleries = from g in _context.Gallery
                                select g;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    galleries = galleries.Where(s => s.City.Contains(SearchString));
                    foreach (var gallery in galleries)
                    {
                        workshops = workshops.Where(s => s.GalleryID.Equals(gallery.GalleryID));
                    }
                }  
                
                Workshop = await workshops.ToListAsync();
            }
        }
    }
}
