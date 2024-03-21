using System.ComponentModel.DataAnnotations;

namespace HappyHoursData.Models
{
	public class Event
	{
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime? Start { get; set; }

        [Required]
        public DateTime? End { get; set; }

        [Required]
        public List<BusinessBranch> BusinessBranches { get; set; } = new();
    }
}