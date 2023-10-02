using AutoMapper;
using Core.Dtos.User;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly SignInManager<UserEntity> signInManager;
        private readonly IJwtService jwtService;
        private readonly IMapper mapper;

        public AccountsService(UserManager<UserEntity> userManager,
                               SignInManager<UserEntity> signInManager,
                               IJwtService jwtService,
                               IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetUserDTO>> GetAll()
        {
            var users = await userManager.Users.ToListAsync();
            return mapper.Map<IEnumerable<GetUserDTO>>(users);
        }
        public async Task<GetUserDTO> Get(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
                throw new HttpException(ErrorMessages.UserByIDNotFound, HttpStatusCode.NotFound);

            var userDto = mapper.Map<GetUserDTO>(user);

            userDto.Roles = (List<string>)await userManager.GetRolesAsync(user);

            return userDto;
        }
        public async Task Edit(string userId, EditUserDTO userDto)
        {
            var user = await userManager.FindByIdAsync(userId);
            string oldFileName = user.ProfilePicture;
            mapper.Map(userDto, user);
            if (userDto.ProfilePicture != null)
                //Add File Edit!!!
                user.ProfilePicture = oldFileName;
            else
                user.ProfilePicture = oldFileName;
            await userManager.UpdateAsync(user);
        }
        public async Task Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                throw new HttpException(ErrorMessages.UserByIDNotFound, HttpStatusCode.NotFound);

            //Add image delete!!!

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                string message = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }


        public async Task<LoginResponseDto> Login(LoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
                throw new HttpException(ErrorMessages.InvalidCreds, HttpStatusCode.BadRequest);

            await signInManager.SignInAsync(user, true);
            return new LoginResponseDto()
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(user))
            };
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(RegisterDto dto)
        {
            UserEntity user = new()
            {
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                RegistrationDate = DateTime.Now.ToUniversalTime(),
                ProfilePicture = "user-default-image.png",
            };

            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                string message = string.Join(", ", result.Errors.Select(x => x.Description));

                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
            await userManager.AddToRoleAsync(user, "user");
        }
        public async Task<bool> CheckEmailExists(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> CheckUsernameExists(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user != null;
        }
    }
}
