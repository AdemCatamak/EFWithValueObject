using System;
using System.Collections.Generic;

namespace EFWithValueObject.Api
{
    public class Address : BaseValueObject
    {
        public string Country { get; private set; }
        public string City { get; private set; }

        public Address(string country, string city)
        {
            if (string.IsNullOrEmpty(country)) throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));

            Country = country;
            City = city;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Country;
            yield return City;
        }
    }
}