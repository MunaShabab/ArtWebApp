using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ArtWebApp.Models;

namespace ArtWebApp.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<ArtWebApp.Models.Customer>? Customer { get; set; }
		public DbSet<ArtWebApp.Models.WorkshopRegisteration>? WorkshopRegisteration { get; set; }
		public DbSet<ArtWebApp.Models.Workshop>? Workshop { get; set; }
		public DbSet<ArtWebApp.Models.Gallery>? Gallery { get; set; }
		public DbSet<ArtWebApp.Models.Show>? Show { get; set; }
		public DbSet<ArtWebApp.Models.ShowPainting>? ShowPainting { get; set; }
		public DbSet<ArtWebApp.Models.Painting>? Painting { get; set; }
		public DbSet<ArtWebApp.Models.Product>? Product { get; set; }

       
    }
}