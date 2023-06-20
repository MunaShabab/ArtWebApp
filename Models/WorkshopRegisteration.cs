using System.ComponentModel.DataAnnotations;

namespace ArtWebApp.Models
{
	public class WorkshopRegisteration
	{
		public int WorkshopRegisterationID { get; set; }
		[Required]
		public int CustomerID { get; set; }
		[Required]
		public int WorkshopID { get; set; }

		public Customer Customer { get; set; }

		public Workshop Workshop { get; set; }
	}
}
