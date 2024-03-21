using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursData.Models
{
	public class BusinessBranch
	{
        public int Id { get; set; }
		
        [Required]
		public Address Address { get; set; } = null!;

		[EmailAddress]
		public string? Email { get; set; } = null!;

		public List<Event>? Events { get; set; }

		[Required]
		public Business Business { get; set; } = null!;

		public List<Customer>? Customers { get; set; } // customers who have (this) branch as favourite
	}
}
