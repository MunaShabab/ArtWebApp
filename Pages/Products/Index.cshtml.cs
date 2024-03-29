﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;

namespace ArtWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public IndexModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product
                .Include(p => p.Painting)
                .Include(p => p.Workshop).ToListAsync();
            }
        }
    }
}
