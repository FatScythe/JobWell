namespace server.Dto.Job
{
    public class CreateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; } = string.Empty;
        public string Type { get; set; }
        public string Location { get; set; }
        public string LocationType { get; set; } = "onsite";
        public string Deadline { get; set; }
    }
}
