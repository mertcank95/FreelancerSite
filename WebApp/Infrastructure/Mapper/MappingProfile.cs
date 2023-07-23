using AutoMapper;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserForCreateDto, IdentityUser>();
        }

    }

}
