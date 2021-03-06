using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Mrv.Domain.Events
{
    public class LeadsEventHandler :
        INotificationHandler<LeadsRegisteredEvent>,
        INotificationHandler<LeadsUpdatedEvent>,
        INotificationHandler<LeadsRemovedEvent>
    {
        public Task Handle(LeadsUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LeadsRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LeadsRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}