using System.ComponentModel.DataAnnotations;

namespace ArtWebApp.Models
{
	public class Workshop
	{
		
		public int WorkshopID { get; set; }

		[Display(Name = "Workshop Title")]
		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string WorkshopTitle { get; set; }

		[Required]

		public int GalleryID { get; set; }
		[Required]
		[Display(Name = "Date")]
		[DataType(DataType.Date)]
		public DateTime WorkshopDate { get; set; }
		[Required]
		[Range(0, 18, ErrorMessage = "The value must be between 0 and 18")]
		public int NumberOfStudents { get; set; }
	
		public ICollection<WorkshopRegisteration>? WorkshopRegisterations { get; set; }
		public virtual Product? Product { get; set; }
	}
}
