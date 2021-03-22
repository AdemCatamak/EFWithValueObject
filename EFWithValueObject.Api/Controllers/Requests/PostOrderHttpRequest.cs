namespace EFWithValueObject.Api.Controllers.Requests
{
    public class PostOrderHttpRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}