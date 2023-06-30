using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtWebApp.Models
{
	public class Show
	{
		
		public int ShowID { get; set; }

		[Display(Name = "Show Title")]
		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string ShowTitle { get; set; }

		[ForeignKey("GalleryID")]
		public int GalleryID { get; set; }

		[Display(Name = "Start Date")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }

		public ICollection<ShowPainting>? ShowPaintings { get; set; }
	}
}
