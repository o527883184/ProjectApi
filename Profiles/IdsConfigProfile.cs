using AutoMapper;
using ProjectApi.Entitys;
using ProjectApi.Models;

namespace ProjectApi.Profiles
{
    public class IdsConfigProfile : Profile
    {
        public IdsConfigProfile()
        {
            CreateMap<IdsApiResource_Create, IdsApiResource>()
                .ForMember(dest => dest.Scopes, opt => opt.MapFrom(
                       src => new Entitys.Scope { Name = src.Name, DisplayName = src.DisplayName, ClaimTypes = src.UserClaims }
                   ));
        }
    }
}
