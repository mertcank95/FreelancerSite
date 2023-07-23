using Entities.Dtos.User;
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
        Task<IdentityResult> CreateUser(UserForCreateDto userDto);
    }
}
