using System.ComponentModel.DataAnnotations;

namespace ArtWebApp.Models
{
	public class Painting
	{
		[Display(Name = "Painting Title")]
		[StringLength(80, MinimumLength = 3)]
		[Required]
		public string PaintingID { get; set; }

		[Required]
		public string Category { get; set; }
		[Required]
		public int Height { get; set; }
		[Required]
		public int Width { get; set; }
		public int Year { get; set; }
		public string Availability { get; set; }
		public string ImageURL { get; set; }

		public ICollection<ShowPainting>? ShowPaintings { get; set; }
		public virtual Product? Product { get; set; }

	}
}
