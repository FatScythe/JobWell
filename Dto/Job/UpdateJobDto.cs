namespace server.Dto.Job
{
    public class UpdateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string LocationType { get; set; } = "onsite";
        public DateOnly Deadline { get; set; }
    }
}
