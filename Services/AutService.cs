using AutoMapper;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AutService : IAutService
    {
    
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AutService(IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(UserForCreateDto userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User Could not be created");
            }
            return result;
        }
    }
}