using AutoMapper;
using Core.Dtos;
using Core.Dtos.User;
using Core.Entities;
//using Core.Entities;
using System.Drawing;

namespace Core.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UserEntity, GetUserDTO>();

            CreateMap<EditUserDTO, UserEntity>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture != null ? Path.GetRandomFileName() : null));
        }
    }
}
