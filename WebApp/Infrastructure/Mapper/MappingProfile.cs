using AutoMapper;
using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<CompanyRegisterDto,Company>().ReverseMap();
            CreateMap<JobPostDto, JobPost>().ReverseMap();
        }

    }

}
