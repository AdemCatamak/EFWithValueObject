using System;

namespace EFWithValueObject.Api.Controllers.Requests
{
    public class GetOrdersHttpRequest
    {
        public Guid? OrderId { get; set; }
        public string? Username { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}