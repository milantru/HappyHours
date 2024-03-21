using System.ComponentModel.DataAnnotations;

namespace HappyHoursData.Models
{
	public class Address
	{
        public int Id { get; set; }

        [Required]
        public string Country { get; set; } = null!;

		[Required]
		public string Region { get; set; } = null!;

		[Required]
		public string City { get; set; } = null!;

		[Required]
		public string Postcode { get; set; } = null!;

		[Required]
		public string StreetName { get; set; } = null!;

		[Required]
		public string StreetNumber { get; set; } = null!;
    }
}