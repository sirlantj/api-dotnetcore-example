using System;
using NetDevPack.Messaging;

namespace Mrv.Domain.Events
{
    public class LeadsUpdatedEvent : Event
    {
        public LeadsUpdatedEvent(Guid newId, int category, int contact, string suburb, 
            decimal price, string status, string description, DateTime dateCreated)
        {
            Id = newId;
            CategoryId = category;
            ContactId = contact;
            Suburb = suburb;
            Price = price;
            Status = status;
            Description = description;
            DateCreated = dateCreated;
            AggregateId = newId;
        }
        public Guid Id { get; private set; }

        public int CategoryId { get; private set; }

        public int ContactId { get; private set; }

        public string Suburb { get; private set; }

        public decimal Price { get; private set; }

        public string Status { get; private set; }

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }
    }
}