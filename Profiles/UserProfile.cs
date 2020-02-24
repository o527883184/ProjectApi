using AutoMapper;
using ProjectApi.Entitys;
using ProjectApi.Models;

namespace ProjectApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, User_Public>();
            CreateMap<User_Public, User>();
        }
    }
}
