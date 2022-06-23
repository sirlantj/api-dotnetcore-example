using AutoMapper;
using Mrv.Application.ViewModels;
using Mrv.Domain.Commands;

namespace Mrv.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LeadsViewModel, RegisterNewLeadsCommand>()
                .ConstructUsing(c => new RegisterNewLeadsCommand(c.categoryId, c.contactId, c.suburb,
                c.price, c.status, c.description, c.dateCreated));
            CreateMap<LeadsViewModel, UpdateLeadsCommand>()
                .ConstructUsing(c => new UpdateLeadsCommand(c.Id, c.categoryId, c.contactId, c.suburb,
                c.price, c.status, c.description, c.dateCreated));
        }
    }
}
