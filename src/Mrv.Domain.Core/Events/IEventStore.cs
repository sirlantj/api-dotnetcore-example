using NetDevPack.Messaging;

namespace Mrv.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}