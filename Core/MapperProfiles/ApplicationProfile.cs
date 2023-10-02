using AutoMapper;
using Core.Dtos.Amount;
using Core.Dtos.Brand;
using Core.Dtos.Parfume;
using Core.Dtos.Perfume;
using Core.Entities;
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
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<UserEntity, GetUserDTO>();

            CreateMap<Amount, AmountDTO>().ReverseMap();
            CreateMap<Amount, CreateAmountDTO>().ReverseMap();

            CreateMap<PerfumeDTO, Parfume>().ReverseMap();
            CreateMap<CreatePerfumeDTO, Parfume>().ReverseMap();
            CreateMap<EditPerfumeDTO, Parfume>().ReverseMap();
            CreateMap<EditUserDTO, UserEntity>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture != null ? Path.GetRandomFileName() : null));
        }
    }
}
