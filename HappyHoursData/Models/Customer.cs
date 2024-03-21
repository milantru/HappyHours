using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursData.Models
{
	public class Customer : User
	{
		[Required]
		public string FirstName { get; set; } = null!;

		[Required]
		public string LastName { get; set; } = null!;

		public Address? Address { get; set; }

		public List<BusinessBranch>? FavouriteBranches { get; set; }
	}
}
