using Core.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task<IEnumerable<GetUserDTO>> GetAll();
        Task<GetUserDTO> Get(string id);
        Task<LoginResponseDto> Login(LoginDto dto);
        Task Register(RegisterDto dto);
        Task Logout();
        Task Delete(string id);
        Task Edit(string userId, EditUserDTO userDto);
        Task<bool> CheckUsernameExists(string userName);
        Task<bool> CheckEmailExists(string email);

    }
}
