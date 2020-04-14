using System.Collections.Generic;
using AutoMapper;
using IdentityServer4.Models;
using ProjectApi.Entitys;
using ProjectApi.Models;

namespace ProjectApi.Profiles
{
    public class IdentityServerProfile : Profile
    {
        public IdentityServerProfile()
        {
            CreateMap<IdsClient_Create, IdsClient>()
                //.ForMember(dest => dest.ClientSecrets, opt => opt.MapFrom(src =>new List<Secret> { new Secret(src.ClientSecret.Sha256()) }))
                .ForMember(dest => dest.RedirectUris, opt => opt.MapFrom(src => new List<string> { src.RedirectUri }))
                .ForMember(dest => dest.PostLogoutRedirectUris, opt => opt.MapFrom(src => new List<string> { src.PostLogoutRedirectUri }));

            CreateMap<IdsApiResource_Create, IdsApiResource>()
                .ForMember(dest => dest.Scopes, opt => opt.MapFrom(
                       src => new Entitys.Scope { Name = src.Name, DisplayName = src.DisplayName, ClaimTypes = src.UserClaims }
                   ));
        }
    }
}
