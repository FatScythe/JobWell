namespace server.Dto.Application
{
    public class UpdateApplicationDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string DoB { get; set; }
        public string Address { get; set; }
        public string Resume { get; set; }
    }
}
