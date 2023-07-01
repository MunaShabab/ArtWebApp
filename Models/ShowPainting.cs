using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtWebApp.Models
{
	
	public class ShowPainting
	{
		
		public int ShowPaintingID { get; set; }
		[Display(Name = "Painting Title")]
        [ForeignKey("PainingID")]
		[Required]
		public string PaintingID { get; set; }
        [ForeignKey("ShowID")]
        [Required]
		public int ShowID { get; set; }
        [DisplayFormat(NullDisplayText = "No award")]
        public string? Award { get; set; }

		public Painting? Painting { get; set; }
		public Show? Show { get; set; }
	}
}
