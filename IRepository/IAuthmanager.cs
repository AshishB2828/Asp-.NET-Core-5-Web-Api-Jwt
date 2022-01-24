using ListingApi.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.IRepository
{
    public interface IAuthmanager
    {

        Task<bool> ValidateUser(LoginUserDto userDto);
        Task<string> CreateToken();
    }
}
