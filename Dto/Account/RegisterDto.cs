using System.ComponentModel.DataAnnotations;

namespace server.Dto.Account
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool isEmployer { get; set; } = false;
    }
}
