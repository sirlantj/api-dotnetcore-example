using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mrv.Domain.Models;
using NetDevPack.Data;

namespace Mrv.Domain.Interfaces
{
    public interface ILeadsRepository : IRepository<Leads>
    {
        Task<Leads> GetById(Guid id);
        
        Task<IEnumerable<Leads>> GetAll();

        void Add(Leads leads);
        void Update(Leads leads);
        void Remove(Leads leads);
    }
}