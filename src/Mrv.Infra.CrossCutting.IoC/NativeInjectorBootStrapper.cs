using Mrv.Application.Interfaces;
using Mrv.Application.Services;
using Mrv.Domain.Commands;
using Mrv.Domain.Core.Events;
using Mrv.Domain.Events;
using Mrv.Domain.Interfaces;
using Mrv.Infra.CrossCutting.Bus;
using Mrv.Infra.Data.Context;
using Mrv.Infra.Data.EventSourcing;
using Mrv.Infra.Data.Repository;
using Mrv.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Mrv.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ILeadsAppService, LeadsAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<LeadsRegisteredEvent>, LeadsEventHandler>();
            services.AddScoped<INotificationHandler<LeadsUpdatedEvent>, LeadsEventHandler>();
            services.AddScoped<INotificationHandler<LeadsRemovedEvent>, LeadsEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewLeadsCommand, ValidationResult>, LeadsCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateLeadsCommand, ValidationResult>, LeadsCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveLeadsCommand, ValidationResult>, LeadsCommandHandler>();

            // Infra - Data
            services.AddScoped<ILeadsRepository, LeadsRepository>();
            services.AddScoped<MrvContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}