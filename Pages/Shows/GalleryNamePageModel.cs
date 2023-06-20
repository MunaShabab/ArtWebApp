using ArtWebApp.Data;
using ArtWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ArtWebApp.Pages.Shows
{
    public class GalleryNamePageModel : PageModel
    {
        public SelectList? GalleryNameSL { get; set; }

        public void PopulateGalleryDropDownList(ApplicationDbContext _context,
            object selectedGallery = null)
        {
            var galleryQuery = from g in _context.Gallery
                                   orderby g.GalleryName // Sort by name.
                                   select g;

            GalleryNameSL = new SelectList(galleryQuery.AsNoTracking(),
                nameof(Gallery.GalleryID),
                nameof(Gallery.GalleryName),
                selectedGallery);
        }
    }
}
