using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mrv.Application.EventSourcedNormalizers;
using Mrv.Application.Interfaces;
using Mrv.Application.ViewModels;
using Mrv.Domain.Commands;
using Mrv.Domain.Interfaces;
using Mrv.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using NetDevPack.Mediator;
using Mrv.Domain.Models;

namespace Mrv.Application.Services
{
    public class LeadsAppService : ILeadsAppService
    {
        private readonly IMapper _mapper;
        private readonly ILeadsRepository _leadsRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public LeadsAppService(IMapper mapper,
                                  ILeadsRepository leadsRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _leadsRepository = leadsRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<Leads>> GetAll()
        {
            return _mapper.Map<IEnumerable<Leads>>(await _leadsRepository.GetAll());
        }

        public async Task<Leads> GetById(Guid id)
        {
            return _mapper.Map<Leads>(await _leadsRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(LeadsViewModel leadsViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLeadsCommand>(leadsViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(LeadsViewModel leadsViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLeadsCommand>(leadsViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveLeadsCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<IList<LeadsHistoryData>> GetAllHistory(Guid id)
        {
            return LeadsHistory.ToJavaScriptLeadsHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
