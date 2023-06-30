using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ArtWebApp.Models
{
	public class Gallery
	{
		
		public int GalleryID { get; set; }
		[Display(Name = "Gallery Name")]

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string GalleryName { get; set; }

		[StringLength(75, MinimumLength = 3)]
		[Required]
		public string Street { get; set; }


		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string City { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string State { get; set; }

		[Display(Name = "Zip Code")]
		[RegularExpression(@"\d{5}-?(\d{4})?$")]
		[Required]
		public int ZipCode { get; set; }

		[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
		[Required]
		[StringLength(40)]
		public string Email { get; set; }
        [Display(Name = "Contact Person")]
        [StringLength(75, MinimumLength = 5)]
		public string ContactPerson { get; set; }
        [Display(Name = "Commission Rate")]
        [Column(TypeName = "decimal(4, 2)")]
		public decimal CommissionRate { get; set; }

		public ICollection<Workshop>? Workshops { get; set; }
		public ICollection<Show>? Shows { get; set; }

	}
}
