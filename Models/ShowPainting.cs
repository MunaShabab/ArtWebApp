using System.ComponentModel.DataAnnotations;

namespace ArtWebApp.Models
{
	
	public class ShowPainting
	{
		
		public int ShowPaintingID { get; set; }
		[Display(Name = "Painting Title")]
		[StringLength(80, MinimumLength = 3)]
		[Required]
		public string PaintingID { get; set; }
		[Required]
		public int ShowID { get; set; }

		[Required]

        public string Award { get; set; }

		public Painting? Painting { get; set; }
		public Show? Show { get; set; }
	}
}
