using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mrv.Domain.Interfaces;
using Mrv.Domain.Models;
using Mrv.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Mrv.Infra.Data.Repository
{
    public class LeadsRepository : ILeadsRepository
    {
        protected readonly MrvContext Db;
        protected readonly DbSet<Leads> DbSet;

        public LeadsRepository(MrvContext context)
        {
            Db = context;
            DbSet = Db.Set<Leads>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Leads> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Leads>> GetAll()
        {
            return await DbSet
                .Include(c => c.Category)
                .Include(c => c.Contact)
                .Include(c => c.Contact)
                .ToListAsync();
        }

        public void Add(Leads leads)
        {
            DbSet.Add(leads);
        }

        public void Update(Leads leads)
        {
            DbSet.Update(leads);
        }

        public void Remove(Leads leads)
        {
            DbSet.Remove(leads);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
