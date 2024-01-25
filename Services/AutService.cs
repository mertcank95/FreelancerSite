using AutoMapper;
using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AutService : IAutService
    {
    
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AutService(IMapper mapper, UserManager<User> userManager, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<(IdentityResult result, User user)> CreateUser(RegisterDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.VerificationToken = Guid.NewGuid().ToString();
            user.UserName = userDto.FirstName;
            var result = await _userManager.CreateAsync(user, userDto.Password);
            return (result, user); ;
        }

        public  User GetUserById(string id)
        {
            return _repositoryManager.UserRepository.GetUserById(id);
        }

        public IQueryable<User> GetIQueryableUser()
        {
            return _repositoryManager.UserRepository.FindAll(true);
        }

        public async Task<IList<string>> GetUserRole(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

    }
}