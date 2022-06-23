using System;
using System.Threading;
using System.Threading.Tasks;
using Mrv.Domain.Events;
using Mrv.Domain.Interfaces;
using Mrv.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace Mrv.Domain.Commands
{
    public class LeadsCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLeadsCommand, ValidationResult>,
        IRequestHandler<UpdateLeadsCommand, ValidationResult>,
        IRequestHandler<RemoveLeadsCommand, ValidationResult>
    {
        private readonly ILeadsRepository _leadsRepository;

        public LeadsCommandHandler(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewLeadsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var leads = new Leads(Guid.NewGuid(), message.CategoryId, message.ContactId, message.Suburb,
                message.Price, message.Status, message.Description, message.DateCreated);

            leads.AddDomainEvent(new LeadsRegisteredEvent(leads.Id, leads.CategoryId, leads.ContactId, leads.Suburb,
                leads.Price, leads.Status, leads.Description, leads.DateCreated));

            _leadsRepository.Add(leads);

            return await Commit(_leadsRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateLeadsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var leads = new Leads(message.Id, message.CategoryId, message.ContactId, message.Suburb,
                message.Price, message.Status, message.Description, message.DateCreated);

            var existingLeads = await _leadsRepository.GetById(leads.Id);

            if (existingLeads != null && existingLeads.Id != leads.Id)
            {
                if (!existingLeads.Equals(leads))
                {
                    AddError("The leader ID has already been taken.");
                    return ValidationResult;
                }
            }
                        
            leads.AddDomainEvent(new LeadsUpdatedEvent(leads.Id, leads.CategoryId, leads.ContactId, leads.Suburb,
                leads.Price, leads.Status, leads.Description, leads.DateCreated));

            _leadsRepository.Update(leads);

            return await Commit(_leadsRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveLeadsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var leads = await _leadsRepository.GetById(message.Id);

            if (leads is null)
            {
                AddError("Leads doesn't exists.");
                return ValidationResult;
            }

            leads.AddDomainEvent(new LeadsRemovedEvent(message.Id));

            _leadsRepository.Remove(leads);

            return await Commit(_leadsRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _leadsRepository.Dispose();
        }
    }
}