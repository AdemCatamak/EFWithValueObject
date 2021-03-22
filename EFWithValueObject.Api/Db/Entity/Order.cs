using System;

namespace EFWithValueObject.Api.Db.Entity
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public Address Address { get; private set; }

        private Order()
        {
            // Only for EF
        }

        public Order(string username, Address address)
            : this(Guid.NewGuid(), username, address)
        {
        }

        public Order(Guid id, string username, Address address)
        {
            Id = id;
            Username = username;
            Address = address;
        }
    }
}