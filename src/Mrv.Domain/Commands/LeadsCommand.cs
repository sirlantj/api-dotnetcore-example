using System;
using NetDevPack.Messaging;

namespace Mrv.Domain.Commands
{
    public abstract class LeadsCommand : Command
    {
        public Guid Id { get; protected set; }

        public int CategoryId { get; protected set; }

        public int ContactId { get; protected set; }

        public string Suburb { get; protected set; }

        public decimal Price { get; protected set; }

        public string Status { get; protected set; }

        public string Description { get; protected set; }

        public DateTime DateCreated { get; protected set; }
    }
}