using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursData.Models
{
	public class Business : User
	{
        [Required]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<BusinessBranch> Branches { get; set; } = new();
    }
}
