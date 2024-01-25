using Entities.Dtos.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAutService
    {
        Task<(IdentityResult result,User user)> CreateUser(RegisterDto userDto);
        Task<IList<string>> GetUserRole(User user);
        User GetUserById(string id);
        IQueryable<User> GetIQueryableUser();

    }
}
