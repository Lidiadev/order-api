namespace Order.Api.Infrastructure.Filters
{
    public class JsonErrorResponse
    {
        public object DeveloperMessage { get; set; }
        public string[] Messages { get; set; }
    }
}
