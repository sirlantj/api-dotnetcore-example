using System;
using NetDevPack.Messaging;

namespace Mrv.Domain.Events
{
    public class LeadsRemovedEvent : Event
    {
        public LeadsRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}