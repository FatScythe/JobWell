using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("Applications")]
    public class Application
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        // Basic Info
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [AllowedValues("male", "female", ErrorMessage = "Gender can only be male or female")]
        public string Gender { get; set; }
        public DateOnly DoB { get; set; }
        public string Address { get; set; }
        public string Resume { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
