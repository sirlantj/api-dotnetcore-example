using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mrv.Application.EventSourcedNormalizers;
using Mrv.Application.ViewModels;
using FluentValidation.Results;
using Mrv.Domain.Models;

namespace Mrv.Application.Interfaces
{
    public interface ILeadsAppService : IDisposable
    {
        Task<IEnumerable<Leads>> GetAll();
        Task<Leads> GetById(Guid id);
        Task<ValidationResult> Register(LeadsViewModel leadsViewModel);
        Task<ValidationResult> Update(LeadsViewModel leads);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<LeadsHistoryData>> GetAllHistory(Guid id);
    }
}
