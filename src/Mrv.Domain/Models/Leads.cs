using System;
using System.Collections.Generic;
using NetDevPack.Domain;

namespace Mrv.Domain.Models
{
    public class Leads : Entity, IAggregateRoot
    {
        public Leads(Guid Newid, int category, int contact, string suburb, decimal price, string status, string description, DateTime dateCreated)
        {
            Id = Newid;
            CategoryId = category;
            ContactId = contact;
            Suburb = suburb;
            Price = price;
            Status = status;
            Description = description;
            DateCreated = dateCreated;
        }

        // Empty constructor for EF
        protected Leads() { }

        public Guid Id { get; private set; }

        public int CategoryId { get; private set; }

        public int ContactId { get; private set; }

        public string Suburb { get; private set; }

        public decimal Price { get; private set; }

        public string Status { get; private set; }

        public string Description { get; private set; }

        public DateTime DateCreated { get; private set; }

        public virtual Category Category { get; set; }

        public virtual Contact Contact { get; set; }
    }
}