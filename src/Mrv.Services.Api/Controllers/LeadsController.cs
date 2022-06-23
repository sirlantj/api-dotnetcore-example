using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mrv.Application.EventSourcedNormalizers;
using Mrv.Application.Interfaces;
using Mrv.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using Mrv.Domain.Models;

namespace Mrv.Services.Api.Controllers
{
    public class LeadsController : ApiController
    {
        private readonly ILeadsAppService _leadsAppService;

        public LeadsController(ILeadsAppService leadsAppService)
        {
            _leadsAppService = leadsAppService;
        }

        [HttpGet("leads")]
        public async Task<IEnumerable<Leads>> Get()
        {
            return await _leadsAppService.GetAll();
        }

        [HttpGet("leads/{id:guid}")]
        public async Task<Leads> Get(Guid id)
        {
            return await _leadsAppService.GetById(id);
        }

        [HttpPost("leads")]
        public async Task<IActionResult> Post([FromBody] LeadsViewModel leadsViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _leadsAppService.Register(leadsViewModel));
        }

        [HttpPut("leads")]
        public async Task<IActionResult> Put([FromBody] LeadsViewModel leadsViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _leadsAppService.Update(leadsViewModel));
        }

        [HttpDelete("leads/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _leadsAppService.Remove(id));
        }

        
        [HttpGet("leads/history/{id:guid}")]
        public async Task<IList<LeadsHistoryData>> History(Guid id)
        {
            return await _leadsAppService.GetAllHistory(id);
        }
        
    }
}
