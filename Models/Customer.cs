
using System.ComponentModel.DataAnnotations;



namespace ArtWebApp.Models
{
	public class Customer
	{
		public int CustomerID { get; set; }
		[Display(Name = "First Name")]

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string FirstName { get; set; }
		[Display(Name = "Last Name")]
		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string LastName { get; set; }

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

		public string FullName
		{
			get
			{
				return LastName + ", " + FirstName;
			}
		}


		public ICollection<WorkshopRegisteration>? WorkshopRegisterations { get; set; }

	}
}

