using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Data;
using ArtWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ArtWebApp.Pages.Customers
{
    [Authorize (Roles = "Admin, Manager")]
    public class IndexModel : PageModel
    {
        
        private readonly ArtWebApp.Data.ApplicationDbContext _context;

        public IndexModel(ArtWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }
        }
    }
}
