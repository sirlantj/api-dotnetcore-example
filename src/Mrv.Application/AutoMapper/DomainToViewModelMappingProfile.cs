using AutoMapper;
using Mrv.Application.ViewModels;
using Mrv.Domain.Models;

namespace Mrv.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Leads, LeadsViewModel>();
        }
    }
}
