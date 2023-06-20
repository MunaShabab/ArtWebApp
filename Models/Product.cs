using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtWebApp.Models
{
	public class Product
	{

		
		public int ProductID { get; set; }

		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
		[Required]
		public decimal Price { get; set; }
		[Required]
		[Range(0, 18, ErrorMessage = "The value must be between 0 and 18")]
		public int AvailableQuantity { get; set; }
		[ForeignKey("WorkshopID")]
		public int? WorkshopID { get; set; }

		[ForeignKey("PaintingID")]
		public string? PaintingID { get; set; }

		public virtual Workshop? Workshop { get; set; }

		public virtual Painting? Painting { get; set; }

	}
}
