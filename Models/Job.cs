using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Jobs")]
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        [AllowedValues("full-time", "contract", "internship", "part-time", "apprenticeship", "graduate-trainee", "trainee")]
        public string Type { get; set; }
        public string Location { get; set; }
        [AllowedValues("remote", "hybrid", "onsite", ErrorMessage = "Location type can only be remote, hybrid or onsite ")]
        public string LocationType { get; set; } = "onsite";
        public DateOnly Deadline { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
