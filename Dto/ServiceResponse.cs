namespace server.Dto
{
    public class ServiceResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Result { get; set; } = new {};
    }
}
